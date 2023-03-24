using BeautySalon.Collection;
using BeautySalon.Exceptions;
using BeautySalon.Logger;
using BeautySalon.Services;
using Newtonsoft.Json;
using System.Configuration;
using System.Xml.Serialization;

namespace BeautySalon
{
    class Serializer
    {
        Logging<Service> log = new Logging<Service>();

        private LList<Service>? list;

        public Serializer(LList<Service> list)
        {
            this.list = list;
        }

        public void ToJSON(string path)
        {
            var filePathConfig = ConfigurationManager.AppSettings.Get("serializeFileNameJson");

            try
            {
                log.LogInformation("Trying write to json");

                File.WriteAllText(
                $"{path}\\{filePathConfig}", JsonConvert.SerializeObject(
                    list, Formatting.Indented, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    }));
            }
            catch (CustomException ex)
            {
                log.LogError("Error writing to json file");
                throw new CustomException(ex.Message, -1);
            }
        }

        public LList<Service>? FromJSON(string path)
        {
            var filePathConfig = ConfigurationManager.AppSettings.Get("serializeFileNameJson");

            LList<Service>? deserializesList = new LList<Service>();

            try
            {
                log.LogInformation("Trying read from json");

                deserializesList = JsonConvert.DeserializeObject<LList<Service>>(
                File.ReadAllText($"{path}\\{filePathConfig}"), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
               
            }
            catch (CustomException ex)
            {
                log.LogError("Error reading from json file");
                throw new CustomException(ex.Message, -1);
            }

            return deserializesList;
        }

        public LList<Service>? FromXML(string path)
        {
            LList<Service>? deserializesList = new LList<Service>();

            var filePathConfig = ConfigurationManager.AppSettings.Get("serializeFileNameXML");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LList<Service>));

            try
            {
                log.LogInformation("Trying read from xml");

                using (FileStream fs = new FileStream($"{path}\\{filePathConfig}", FileMode.OpenOrCreate))
                {
                    deserializesList = xmlSerializer.Deserialize(fs) as LList<Service>;
                }
            }
            catch (CustomException ex)
            {
                log.LogError("Error reading from xml file");

                throw new CustomException($"Error reading from xml file, , {ex.Message}", -1);
            }

            return deserializesList;
        }

        public void ToXML(string path)
        {
            var filePathConfig = ConfigurationManager.AppSettings.Get("serializeFileNameXML");


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LList<Service>));

            try
            {
                log.LogInformation("Trying write to xml");

                using (FileStream fs = new FileStream($"{path}\\{filePathConfig}", FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, list);
                }
            }
            catch (CustomException ex)
            {
                log.LogError("Error writing to xml file");

                throw new CustomException($"Error writing to xml file, {ex.Message}", -1);
            }
        }

    }
}
