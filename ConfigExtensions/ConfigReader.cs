using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GameLibrary.ConfigExtensions
{
    public static class ConfigReader
    {
        static readonly string CONFIG_FILEPATH = Directory.GetCurrentDirectory();
        public static GameConfigurations ReadConfig(string configFileName)
        {
            GameConfigurations conf = new GameConfigurations();
            var path = Path.Combine(CONFIG_FILEPATH, configFileName + ".txt");

            XmlDocument configDoc = new XmlDocument();
            configDoc.Load(path);

            conf.GameName = GetValue<string>(configDoc,"GameName");
            conf.LogName = GetValue<string>(configDoc,"LogName");
            conf.DoLog = GetValue<bool>(configDoc,"DoLog");

            return conf;
        }

        public static T GetValue<T>(XmlDocument configDoc, string valueName)
        {
            XmlNode LogName = configDoc.DocumentElement.SelectSingleNode(valueName);
            if (LogName != null)
            {
                String str = LogName.InnerText.Trim();
                return (T)Convert.ChangeType(str, typeof(T));
            }
            return default;
        }
    }
}
