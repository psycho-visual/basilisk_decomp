using System.Xml.Linq;

namespace Razer.ActionService
{
	public interface IRazerSerializable
	{
		XElement Serialize();
	}
}
