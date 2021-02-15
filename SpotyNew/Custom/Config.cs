using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace SpotyNew.Custom
{
    class Config
    {
        const string configName = "./config.json";

        public static configClass userConfig;

        public static void Init()
        {
            if (File.Exists(configName))
            {
                userConfig = JsonConvert.DeserializeObject<configClass>(File.ReadAllText(configName));
            }
            else
            {
                userConfig = new configClass();
                string outputJSON = JsonConvert.SerializeObject(userConfig, Formatting.Indented);
                File.AppendAllText(configName, outputJSON);
            }
        }

        public static void Sync()
        {
            string jsonString = File.ReadAllText(configName);
            // Convert the JSON string to a JObject:
            JObject jObject = JsonConvert.DeserializeObject(jsonString) as JObject;

            int index = 0;
            var cFields = userConfig.GetType().GetFields();
            foreach (var key in jObject)
            {
                var cValue = cFields[index].GetValue(userConfig);
                JToken value = key.Value;
                dynamic dValue = cValue;
                value.Replace(dValue);
                index++;
            }

            string updatedJsonString = jObject.ToString();

            File.WriteAllText(configName, updatedJsonString);
        }
    }
}
