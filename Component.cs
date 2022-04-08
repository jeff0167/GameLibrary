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
        /// <summary>
        /// The component class is a abstract class we want want any script behaviour to inherit from, like health
        /// A component is supposed to be attached to a gameobject which can have as many components as it likes
        /// An example could be a gameobject which we want to attack and have health we could give it health and weapon
        /// components so it has those features
        /// </summary>
        public string Name { get; } 
        public IObserver Observer;
        /// <summary>
        /// We simply give it a name to identify it by if we would like and a parent gameobject which this component is attached to
        /// </summary>
        /// <param name="name"> The name of the component which can be set to help distinguish created components</param>
        /// <param name="observer"> The observer is the reference to the gameobject the component is attached to if any</param>
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
            return MyExtensions.ToStringExtension(this);
        }
    }
}
