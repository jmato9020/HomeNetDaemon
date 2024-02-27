using HomeNetDaemon.Core.Lights.Data;
namespace HomeNetDaemon.Core.Xml.Root;

public class SceneXmlRoot
{
  public List<SceneData> Scenes { get; set; } = new List<SceneData>();
}
