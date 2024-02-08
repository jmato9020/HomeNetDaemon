using HomeNetDaemon.Access;
using HNDA = HomeNetDaemon.Access;

namespace HomeNetDaemon.Core;

public class LightController
{
  LightEntity m_lightEntity;

  public LightController(LightEntity lightEntity)
  {
    m_lightEntity = lightEntity;
  }

  public void Toggle(){
    m_lightEntity.Toggle();
  }

}
