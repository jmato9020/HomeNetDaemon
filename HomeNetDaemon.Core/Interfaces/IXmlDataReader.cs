using System.Xml.Serialization;
using HomeNetDaemon.Core.Xml.Root;
namespace HomeNetDaemon.Core;

public interface IXmlDataReader<T>
{
  public XmlSerializer Serializer { get; set; }

  public T Read(string filepath);
}
