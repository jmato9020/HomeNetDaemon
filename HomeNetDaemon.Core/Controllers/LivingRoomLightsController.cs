using HomeNetDaemon.Access;
using NetDaemon.HassModel.Entities;

namespace HomeNetDaemon.Core;

public class LivingRoomLightsController
{
  #region Light entities
  LightEntity TvLeftLight;

  LightEntity TvRightLight;

  LightEntity CouchLight;

  List<LightEntity> LivingRoomLights { get; }

  #endregion

  #region Scenes
  SceneEntity HomeScene;
  #endregion


  public LivingRoomLightsController(Entities entities)
  {
    TvLeftLight = entities.Light.Tvl;
    TvRightLight = entities.Light.Tvr;
    CouchLight = entities.Light.Couch;

    LivingRoomLights = new List<LightEntity>(){
      TvLeftLight,
      TvRightLight,
      CouchLight
    };

    HomeScene = entities.Scene.LivingRoomHome;
  }

  public void ToggleHomeScene(){

    if(HomeScene.IsOn()){
      LivingRoomLights.ForEach(l=>l.TurnOff());
    }
    else{
      HomeScene.TurnOn();
    }
  }

}
