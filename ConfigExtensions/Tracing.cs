using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.ConfigExtensions
{
    public class Tracing
    {
        public TraceSource ts = new TraceSource("Epic Game");
        private static Tracing _Instance;

        public static Tracing Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Tracing();
                }
                return _Instance;
            }
        }
        public void Setup()
        {
            ts.Switch = new SourceSwitch("Game Log", "All");
            
            // setting up listeners
            //TraceListener consoleLog = new ConsoleTraceListener();
            //ts.Listeners.Add(consoleLog);
            var stream = new StreamWriter("TraceDemo.txt"); // autosave
            stream.AutoFlush = true;
            TraceListener fileLog = new TextWriterTraceListener(stream);
            ts.Listeners.Add(fileLog);
        }
    }
}
