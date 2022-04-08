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
        public TraceSource ts; // = "Epiq Game"
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
        public void Setup(string Gamename, string logName, bool DoConsoleLog = false)
        {
            ts = new TraceSource(Gamename);
            ts.Switch = new SourceSwitch(logName, "All");
            // setting up listeners
            if (DoConsoleLog)
            {
                Console.WriteLine("Doing console log");
                TraceListener consoleLog = new ConsoleTraceListener();
                ts.Listeners.Add(consoleLog);
            }
            var stream = new StreamWriter(logName + ".txt"); // autosave
            stream.AutoFlush = true;
            TraceListener fileLog = new TextWriterTraceListener(stream);
            ts.Listeners.Add(fileLog);
        }
    }
}
