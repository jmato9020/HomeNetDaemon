using System.Xml.Serialization;
using HomeNetDaemon.Core.Xml.Root;

namespace HomeNetDaemon.Core;

public class SceneXmlReader : IXmlDataReader<SceneXmlRoot>
{

  public SceneXmlReader()
  {
  }

  #region IXmlDataReader implementation
  public XmlSerializer Serializer { get; set; } = new XmlSerializer(typeof(SceneXmlRoot));

  public SceneXmlRoot Read(string filepath)
  {
    throw new NotImplementedException();
  }
  #endregion
}