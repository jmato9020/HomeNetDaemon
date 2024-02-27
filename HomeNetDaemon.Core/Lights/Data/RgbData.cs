namespace HomeNetDaemon.Core.Lights.Data;

public class RgbData
{
  public string LightName = string.Empty;
  public double Red;

  public double Green;

  public double Blue;

  public RgbData()
  {
    Red = 0;
    Green = 0;
    Blue = 0;
  }

  public RgbData(double r, double g, double b)
  {
    Red = r;
    Green = g;
    Blue = b;
  }
  public RgbData(double r, double g, double b, string Name)
  {
    Red = r;
    Green = g;
    Blue = b;
    LightName = Name;
  }
  public RgbData(RgbData rgbData, string Name)
  {
    Red = rgbData.Red;
    Green = rgbData.Green;
    Blue = rgbData.Blue;
    LightName = Name;
  }
}
