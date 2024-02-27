using HomeNetDaemon.Access;
using HomeNetDaemon.Core.Lights.Data;
using HomeNetDaemon.Core.Xml.Root;
using NetDaemon.HassModel.Entities;

namespace HomeNetDaemon.Core.Lights.Controllers;

public class LivingRoomLightsController
{
  #region Light entities
  LightController TvLeftLight;

  LightController TvRightLight;

  LightController CouchLight;

  List<LightController> LivingRoomLights { get; }

  #endregion

  #region Scenes
  SceneEntity HomeScene;

  SceneEntity DimmedScene;

  SceneEntity MovieScene;

  List<SceneEntity> LivingRoomScenes;
  #endregion

  public LivingRoomLightsController(Entities entities)
  {
    TvLeftLight = new LightController(entities.Light.Tvl);
    TvRightLight = new LightController(entities.Light.Tvr);
    CouchLight = new LightController(entities.Light.Couch);

    LivingRoomLights = new List<LightController>(){
      TvLeftLight,
      TvRightLight,
      CouchLight
    };

    HomeScene = entities.Scene.LivingRoomHome;

    DimmedScene = entities.Scene.LivingRoomDimmed;

    MovieScene = entities.Scene.MovieLights;

    LivingRoomScenes = new List<SceneEntity>(){
      HomeScene,
      DimmedScene,
      MovieScene
    };

  }

  public SceneData GetSceneData()
  {
    var LivingRoomScene = new SceneData();
    var LivingRoomSceneRgbData = LivingRoomLights.Select((element) => { return new RgbData(element.CurrentRgb, element.ToString()); }).ToList();
    LivingRoomScene.LightValues = LivingRoomSceneRgbData;
    LivingRoomScene.SceneName = "";
    return LivingRoomScene;
  }
  public SceneData GetSceneData(SceneEntity scene)
  {
    scene.TurnOn();
    System.Threading.Thread.Sleep(1000);
    var LivingRoomScene = new SceneData();
    var LivingRoomSceneRgbData = LivingRoomLights.Select((element) => { return new RgbData(element.CurrentRgb, element.ToString()); }).ToList();
    LivingRoomScene.LightValues = LivingRoomSceneRgbData;
    LivingRoomScene.SceneName = scene.EntityId;
    return LivingRoomScene;
  }
  public List<SceneData> ScanScenes()
  {
    List<SceneData> sceneData = new List<SceneData>();
    foreach (var scene in LivingRoomScenes)
    {
      sceneData.Add(GetSceneData(scene));
    }
    return sceneData;
  }
  public void ToggleHomeScene()
  {
    if (HomeScene.IsOn())
    {
      LivingRoomLights.ForEach(l => l.TurnOff());
    }
    else
    {
      HomeScene.TurnOn();
    }
  }

}
