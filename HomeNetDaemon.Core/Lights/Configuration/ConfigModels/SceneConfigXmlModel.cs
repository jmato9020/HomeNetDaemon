using HomeNetDaemon.Core.Lights.Data;

namespace HomeNetDaemon.Core.Lights.Configuration.Models;

public class SceneConfigXmlModel
{
  public string SceneName;

  public Dictionary<string, RgbData> RgbLightsForSceneDict;

  public SceneConfigXmlModel(string sceneName)
  {
    SceneName = sceneName;
    RgbLightsForSceneDict = new Dictionary<string, RgbData>();
  }
  
  public SceneConfigXmlModel(string sceneName, Dictionary<string, RgbData> rgbLightValues)
  {
    SceneName = sceneName;
    RgbLightsForSceneDict = rgbLightValues;
  }

}
