using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.ConfigExtensions;

namespace GameLibrary
{
    public abstract class Component
    {
        public string Name { get; }

        protected Component(string name)
        {
            Tracing.Instance.ts.TraceEvent(TraceEventType.Information, 333, "New component created of type: " + this.GetType().Name);
            Name = name;
        }
        public override string ToString()
        {
            Console.WriteLine(MyExtensions.ToStringExtension(this));
            return "";
        }
    }
}
