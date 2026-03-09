using System.IO;
using System.Text;
using System.Xml.Serialization;
using EasyCodeBuilder;
using EasyCodeBuilder.Application.Interfaces;

namespace EasyCodeBuilder.Infrastructure.Services
{
    /// <summary>
    /// プロジェクト永続化サービスの実装
    /// </summary>
    public class ProjectPersistenceService : IProjectPersistenceService
    {
        public void SaveProject(string filePath, ProgramDefine programDefine)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                File.WriteAllText(filePath, ToXmlString(programDefine), Encoding.UTF8);
            }
        }

        public ProgramDefine LoadProject(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(ProgramDefine));
                return (ProgramDefine)serializer.Deserialize(stream);
            }
        }

        public string ToXmlString(ProgramDefine programDefine)
        {
            using (var stream = new StringWriterUtf8())
            {
                var serializer = new XmlSerializer(typeof(ProgramDefine));
                serializer.Serialize(stream, programDefine);
                return stream.ToString();
            }
        }
    }
}
