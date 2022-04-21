using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GameLibrary
{
    public class GameConfigurations
    {
        public string GameName { get; set; }
        public string LogName { get; set; }
        public bool DoLog { get; set; }
        public GameConfigurations(string gameName, string logName, bool doLog = false)
        {
            GameName = gameName;
            LogName = logName;
            DoLog = doLog;
        }
        public GameConfigurations()
        {
            GameName = "Epiq Game";
            LogName = "Log";
            DoLog = false;
        }
    }
}
