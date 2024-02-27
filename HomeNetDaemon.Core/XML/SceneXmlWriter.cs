using System.Xml;
using System.Xml.Serialization;
using HomeNetDaemon.Core.Interfaces;
using HomeNetDaemon.Core.Xml.Root;

namespace HomeNetDaemon.Core.Xml;

public class SceneXmlWriter : IXmlDataWriter<SceneXmlRoot>
{
  private XmlSerializer m_sceneWriter = new XmlSerializer(typeof(SceneXmlRoot));

  public XmlSerializer Serializer
  {
    get
    {
      return m_sceneWriter;
    }
    set
    {
      m_sceneWriter = value;
    }
  }
  public SceneXmlWriter()
  {

  }

  public void Write(string filename, SceneXmlRoot sceneData)
  {
    TextWriter writer = new StreamWriter(filename);
    m_sceneWriter.Serialize(writer, sceneData);
  }

  public MemoryStream ToStream(SceneXmlRoot sceneData)
  {
    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Indent = true;
    var ms = new MemoryStream();
    using (XmlWriter writer = XmlWriter.Create(ms, settings))
    {
      writer.WriteStartDocument();
      m_sceneWriter.Serialize(writer, sceneData);
      writer.WriteEndDocument();
      writer.Flush();
    }
    return ms;
  }
}
