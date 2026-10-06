using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	public abstract class HandlerBase<ReturnType>
	{
		private ReturnType m_return;

		private RzServiceType m_serviceType;

		private Commands m_command;

		private Exception m_exception;

		private ClientPipeSocket m_socket;

		private AutoResetEvent m_event;

		private bool m_disconnected;

		private static int m_packetCount;

		private int m_packetNumber;

		private HandlerBase()
		{
		}

		public HandlerBase(ClientPipeSocket socket, RzServiceType serviceType, Commands command)
		{
			m_socket = socket;
			m_serviceType = serviceType;
			m_command = command;
			m_disconnected = false;
			m_exception = null;
			m_event = new AutoResetEvent(initialState: false);
			m_socket.AddReceiveHandler(m_serviceType, OnReceive);
			m_socket.OnDisconnect += OnDisconnect;
		}

		protected ReturnType Send(byte[] data)
		{
			try
			{
				m_packetNumber = Interlocked.Increment(ref m_packetCount);
				byte[] data2;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
					{
						binaryWriter.Write((uint)m_command);
						binaryWriter.Write(m_packetNumber);
						if (data != null)
						{
							binaryWriter.Write(data);
						}
					}
					data2 = memoryStream.ToArray();
				}
				m_socket.Send(m_serviceType, data2);
				if (!m_event.WaitOne(GetTimeout()))
				{
					throw new TimeoutException(string.Concat("Timeout waiting for ", m_command, " response"));
				}
				if (m_disconnected)
				{
					throw new IOException("Broken pipe");
				}
				if (m_exception != null)
				{
					throw m_exception;
				}
				return m_return;
			}
			finally
			{
				m_socket.RemoveReceiveHandler(m_serviceType, OnReceive);
				m_socket.OnDisconnect -= OnDisconnect;
			}
		}

		private void OnReceive(ClientPipeSocket socket, long packetId, byte[] data)
		{
			if (!ResponseFlagSet(data))
			{
				return;
			}
			Commands commands = (Commands)BitConverter.ToUInt32(data, 0);
			if ((commands & (Commands)1073741823u) != m_command || BitConverter.ToInt32(data, 4) != m_packetNumber)
			{
				return;
			}
			if ((commands & Commands.Exception) != Commands.Undefined)
			{
				HandleException(data);
			}
			else
			{
				try
				{
					m_return = Deserialize(data.Skip(8).ToArray());
				}
				catch (Exception innerException)
				{
					m_exception = new Exception(string.Concat("Failed to read ", commands, " response"), innerException);
				}
			}
			m_event.Set();
		}

		private void OnDisconnect(ClientPipeSocket socket)
		{
			m_disconnected = true;
			m_event.Set();
		}

		private bool ResponseFlagSet(byte[] data)
		{
			return (data[3] & 0x80) == 128;
		}

		private void HandleException(byte[] data)
		{
			ExceptionTypes exceptionTypes = ExceptionTypes.General;
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadInt32();
					binaryReader.ReadInt32();
					exceptionTypes = (ExceptionTypes)binaryReader.ReadUInt32();
					string text = binaryReader.ReadString();
					switch (exceptionTypes)
					{
					case ExceptionTypes.Cop:
					{
						int code = binaryReader.ReadInt32();
						m_exception = new CopException(text, code);
						break;
					}
					case ExceptionTypes.NotImplemented:
						m_exception = new NotImplementedException(text);
						break;
					case ExceptionTypes.InvalidOperation:
						m_exception = new InvalidOperationException(text);
						break;
					case ExceptionTypes.OtpRequired:
					{
						XElement element = XElement.Parse(binaryReader.ReadString());
						m_exception = new OtpRequiredException(element);
						break;
					}
					case ExceptionTypes.OtpFailed:
					{
						string transactionId = binaryReader.ReadString();
						int num = binaryReader.ReadInt32();
						List<TfaMethod> list = new List<TfaMethod>(num);
						for (int i = 0; i < num; i++)
						{
							list.Add(binaryReader.Read<TfaMethod>());
						}
						m_exception = new OtpFailedException(transactionId, list);
						break;
					}
					case ExceptionTypes.License:
					{
						LicenseResult result = (LicenseResult)binaryReader.ReadInt32();
						m_exception = new LicenseException(text, result);
						break;
					}
					case ExceptionTypes.ArgumentOutOfRange:
						m_exception = new ArgumentOutOfRangeException(text);
						break;
					case ExceptionTypes.ProfileIncomplete:
						m_exception = new UserProfileIncompleteException(XDocument.Parse(binaryReader.ReadString()));
						break;
					case ExceptionTypes.AccountNotLinked:
						m_exception = new AccountNotLinkedException(text, XDocument.Parse(binaryReader.ReadString()));
						break;
					case ExceptionTypes.ConsentRequired:
					{
						string scope = binaryReader.ReadString();
						m_exception = new ConsentRequiredException(scope);
						break;
					}
					default:
						m_exception = new Exception(text);
						break;
					}
				}
			}
		}

		protected abstract ReturnType Deserialize(byte[] data);

		protected virtual int GetTimeout()
		{
			return 30000;
		}
	}
}
