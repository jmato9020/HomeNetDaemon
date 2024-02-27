using System.Xml;
using System.Xml.Serialization;

namespace HomeNetDaemon.Core.Interfaces;

public interface IXmlDataWriter<T>
{
  public XmlSerializer Serializer { get; set; }

  public void Write(string filename,T data);
}
