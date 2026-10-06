using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Razer.ActionService
{
	public static class SerializationExtensions
	{
		public static void Write(this BinaryWriter writer, SystemTrayRoot root)
		{
			XDocument xDocument = new XDocument(root.Serialize());
			writer.Write(xDocument.ToString());
		}

		public static SystemTrayRoot ReadSystemTrayRoot(this BinaryReader reader)
		{
			return new SystemTrayRoot(XDocument.Parse(reader.ReadString()).Element("SystemTrayRoot"));
		}

		public static void Write(this BinaryWriter writer, SystemTrayItem item)
		{
			XDocument xDocument = new XDocument(item.Serialize());
			writer.Write(xDocument.ToString());
		}

		public static SystemTrayItem ReadSystemTrayItem(this BinaryReader reader)
		{
			return new SystemTrayItem(XDocument.Parse(reader.ReadString()).Element("SystemTrayItem"));
		}

		public static void Write(this BinaryWriter writer, RazerDevice device)
		{
			new DataContractSerializer(typeof(RazerDevice)).WriteObject(writer.BaseStream, device);
		}

		public static RazerDevice ReadRazerDevice(this BinaryReader reader)
		{
			return new DataContractSerializer(typeof(RazerDevice)).ReadObject(reader.BaseStream) as RazerDevice;
		}

		public static void Write(this BinaryWriter writer, IEnumerable<RazerDevice> device)
		{
			new DataContractSerializer(typeof(List<RazerDevice>)).WriteObject(writer.BaseStream, device.ToList());
		}

		public static void Write(this BinaryWriter writer, IEnumerable<string> stringList)
		{
			if (stringList != null)
			{
				new DataContractSerializer(typeof(List<string>)).WriteObject(writer.BaseStream, stringList.ToList());
			}
		}

		public static List<RazerDevice> ReadRazerDeviceList(this BinaryReader reader)
		{
			return new DataContractSerializer(typeof(List<RazerDevice>)).ReadObject(reader.BaseStream) as List<RazerDevice>;
		}

		public static void Write(this BinaryWriter writer, Bitmap image)
		{
			writer.Write(image != null);
			if (image == null)
			{
				return;
			}
			using (MemoryStream memoryStream = new MemoryStream())
			{
				image.Save(memoryStream, ImageFormat.Png);
				byte[] inArray = memoryStream.ToArray();
				writer.Write(Convert.ToBase64String(inArray));
			}
		}

		public static Bitmap ReadBitmap(this BinaryReader reader)
		{
			if (!reader.ReadBoolean())
			{
				return null;
			}
			using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(reader.ReadString())))
			{
				return new Bitmap(stream);
			}
		}

		public static void Write(this BinaryWriter writer, IRazerSerializable item)
		{
			XDocument xDocument = new XDocument(item.Serialize());
			writer.Write(xDocument.ToString());
		}

		public static T Read<T>(this BinaryReader reader) where T : class, IRazerSerializable
		{
			XDocument xDocument = XDocument.Parse(reader.ReadString());
			try
			{
				return (T)Activator.CreateInstance(typeof(T), xDocument);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static void Write(this BinaryWriter writer, IEnumerable<IRazerSerializable> item)
		{
			XDocument xDocument = new XDocument(new XElement("Item", item.Select((IRazerSerializable x) => x.Serialize())));
			writer.Write(xDocument.ToString());
		}

		public static IEnumerable<T> ReadAll<T>(this BinaryReader reader) where T : class, IRazerSerializable
		{
			try
			{
				XDocument xDocument = XDocument.Parse(reader.ReadString());
				List<T> list = new List<T>();
				foreach (XElement item in xDocument.Element("Item").Elements())
				{
					list.Add((T)Activator.CreateInstance(typeof(T), item));
				}
				return list;
			}
			catch
			{
				return Enumerable.Empty<T>();
			}
		}
	}
}
