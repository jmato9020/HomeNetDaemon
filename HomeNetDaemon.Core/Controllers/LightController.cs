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

  private IReadOnlyList<double>? GetCurrentColorRgb(){
    return m_lightEntity.Attributes?.RgbColor;
  }

  public string ReadRgbAsString(){
    var color = GetCurrentColorRgb();
    if(color!=null){
      return $"R:{color[0]} G:{color[1]} B:{color[2]}" ;
    }
    else{
      return string.Empty;
    }
  }
}
