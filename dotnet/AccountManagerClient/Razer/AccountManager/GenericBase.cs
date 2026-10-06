using System.Collections.Generic;
using System.IO;
using System.Linq;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal abstract class GenericBase<T> : HandlerBase<T>
	{
		private int m_timeout = 30000;

		public GenericBase(ClientPipeSocket socket, Commands command)
			: base(socket, RzServiceType.AccountManager, command)
		{
		}

		public T Execute()
		{
			return Send(null);
		}

		public T Execute(string str)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(str);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		public T Execute(string str1, string str2)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(str1);
					binaryWriter.Write(str2);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		public T Execute(IEnumerable<string> strings)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(strings.Count());
					foreach (string @string in strings)
					{
						binaryWriter.Write(@string);
					}
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		public T Execute(IEnumerable<string> strings, string str1, string str2)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(str1);
					binaryWriter.Write(str2);
					binaryWriter.Write(strings.Count());
					foreach (string @string in strings)
					{
						binaryWriter.Write(@string);
					}
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		public T Execute(IEnumerable<IRazerSerializable> items, string str1, string str2)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(str1);
					binaryWriter.Write(str2);
					binaryWriter.Write(items.Count());
					foreach (IRazerSerializable item in items)
					{
						binaryWriter.Write(item);
					}
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		public T Execute(AccountMode mode)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write((uint)mode);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		public T Execute(IRazerSerializable param)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter(memoryStream))
				{
					writer.Write(param);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		public T Execute(IEnumerable<IRazerSerializable> items)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter(memoryStream))
				{
					writer.Write(items);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		public T Execute(IEnumerable<RazerDevice> devices)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter(memoryStream))
				{
					writer.Write(devices);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		public T Execute(int value)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(value);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		public T Execute(double value)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(value);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		public T Execute(string product, string path, string name, SettingSource source, SettingSource autoResolvePolicy = SettingSource.Undefined)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(product);
					binaryWriter.Write(path);
					binaryWriter.Write(name);
					binaryWriter.Write((uint)source);
					binaryWriter.Write((uint)autoResolvePolicy);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		public T Execute(string product, RzSetting setting, SettingSaveType type)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(product);
					binaryWriter.Write((IRazerSerializable)setting);
					binaryWriter.Write((uint)type);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		public T Execute(string str1, string str2, string str3)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(str1);
					binaryWriter.Write(str2);
					binaryWriter.Write(str3);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		public T Execute(string str1, string str2, string str3, string str4, bool bool1)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(str1);
					binaryWriter.Write(str2);
					binaryWriter.Write(str3);
					binaryWriter.Write(str4);
					binaryWriter.Write(bool1);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		public GenericBase<T> WithTimeout(int timeout)
		{
			m_timeout = timeout;
			return this;
		}

		protected override int GetTimeout()
		{
			return m_timeout;
		}
	}
}
