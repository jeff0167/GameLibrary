using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using GameLibrary.ConfigExtensions;
using GameLibrary.Interfaces;

namespace GameLibrary
{
    public class GameObject : IObserver
    {
        public string name;
        public string tag;   // technically the parent gameobject has the tag
        public int id;
        public Vector2 position;
        private List<Component> components; // could we make the sceneworld observe the ctor and add it?

        public GameObject(Vector2 pos, string _name) // I think gameobjects should add listeners when ever it adds a component
        {
            Tracing.Instance.ts.TraceEvent(TraceEventType.Information, 333, "New gameobject created of type: " + this.GetType().Name);
            name = _name;
            position = pos;
            components = new List<Component>();
        }

        public GameObject Update()
        {
            return this;
        }

        public void AddComponent(Component component)
        {
            component.AddObserver(this);
            components.Add(component);
            Console.WriteLine("Added component: " + component.Name + " to gameobject: " + this.name);
        }

        public void RemoveComponent(Component component)
        {
            components.Remove(component);
        }

        public T GetComponent<T>()
        {
            var t = typeof(T);
            foreach (var item in components)
            {
                if (item.GetType() == t)
                {
                    return (T)Convert.ChangeType(item, t);
                }
            }
            return default;
        }
        public Component GetComponentByName<T>(string name) // name is not unique you could end op just getting the first item with the name
        {
            return components.FirstOrDefault(x => x.Name == name);
        }

        public List<Component> GetComponents()
        {
            return components;
        }

        public override string ToString()
        {
            Console.WriteLine(MyExtensions.ToStringExtension(this));
            return "";
        }

        // components such as      i think script must be components as well so as with health and dmg must be simple components that can be added to a gameobject
        //
        // sprite renderer
        // colliders
        // health
        // dmg
        // pickup
        // weapon
        // shields
        // inputManager
        // soundManager
        //
        // Some kind of engine with configurations

    }
}
