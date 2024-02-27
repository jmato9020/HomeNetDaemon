using System.Xml.Serialization;
using HomeNetDaemon.Core.Lights.Data;

namespace HomeNetDaemon.Core.Lights.Data;

[XmlRoot("Scene")]
public class SceneData
{
  
  public string SceneName = string.Empty;

  [XmlElement(ElementName ="Lights")]
  public List<RgbData> LightValues = new List<RgbData>();

}
