using HomeNetDaemon.Access;
using HomeNetDaemon.Core.Lights.Data;

namespace HomeNetDaemon.Core.Lights.Controllers;

public class LightController
{
  LightEntity m_lightEntity;

  public RgbData CurrentRgb
  {
    get
    {
      var color = GetCurrentColorRgb();
      if (color != null)
      {
        return new RgbData(color[0], color[1], color[2]);
      }
      else
      {
        return new RgbData(0, 0, 0);
      }
    }
  }

  public LightController(LightEntity lightEntity)
  {
    m_lightEntity = lightEntity;
  }

  public void Toggle()
  {
    m_lightEntity.Toggle();
  }

  public void TurnOn()
  {
    m_lightEntity.TurnOn();
  }
  public void TurnOff()
  {
    m_lightEntity.TurnOff();
  }

  private IReadOnlyList<double>? GetCurrentColorRgb()
  {
    return m_lightEntity.Attributes?.RgbColor;
  }

  public string ReadRgbAsString()
  {
    var color = GetCurrentColorRgb();
    if (color != null)
    {
      return $"R:{color[0]} G:{color[1]} B:{color[2]}";
    }
    else
    {
      return string.Empty;
    }
  }
  public override string ToString()
  {
    return m_lightEntity.EntityId;
  }
}
