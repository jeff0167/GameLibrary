using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.ConfigExtensions;
using GameLibrary.Interfaces;

namespace GameLibrary
{
    public abstract class Component : ISubject
    {
        public string Name { get; }

        public IObserver Observer;

        protected Component(string name, IObserver observer = null)
        {
            Tracing.Instance.ts.TraceEvent(TraceEventType.Information, 333, "New component created of type: " + this.GetType().Name);
            Name = name;
            Observer = observer;
        }

        public void AddObserver(IObserver observer)
        {
            Observer = observer;
        }

        public override string ToString()
        {
            Console.WriteLine(MyExtensions.ToStringExtension(this));
            return "";
        }
    }
}
