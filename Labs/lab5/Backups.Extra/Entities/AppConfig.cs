using System.IO;
using Backups.Tools;
using Newtonsoft.Json;

namespace Backups.Extra.Entities
{
    public class AppConfig<T>
    {
        private string _filePath;
        private T _serializeObject;

        private JsonSerializerSettings _serializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented,
        };

        public AppConfig(string filePath, T serializeObject)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new BackupsException("Incorrect path");
            
            _filePath = filePath;
            _serializeObject = serializeObject;
        }

        public void Save()
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(_serializeObject, _serializerSettings));
        }

        public T Load()
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(_filePath), _serializerSettings);
        }
    }
}