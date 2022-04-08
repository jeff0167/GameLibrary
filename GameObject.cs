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
        /// <summary>
        /// Gameobjects are physical objects in the game world that can be given features as components that can extend
        /// the usability of the gameobject
        /// All gameobjects have a position
        /// </summary>
        public string name;
        public string tag;   // technically the parent gameobject has the tag
        public int id;
        public Vector2 position;
        private List<Component> components; // could we make the sceneworld observe the ctor and add it?
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"> Start position</param>
        /// <param name="_name"> Name to help developer identify gameobject by</param>
        public GameObject(Vector2 pos, string _name) // I think gameobjects should add listeners when ever it adds a component
        {
            Tracing.Instance.ts.TraceEvent(TraceEventType.Information, 333, "New gameobject created of type: " + this.GetType().Name);
            name = _name;
            position = pos;
            components = new List<Component>();
        }
        /// <summary>
        /// We return this gameobject to a subject
        /// </summary>
        /// <returns></returns>
        public GameObject Update()
        {
            return this;
        }
        /// <summary>
        /// Adds a component to the gamobject
        /// </summary>
        /// <param name="component"></param>
        public void AddComponent(Component component)
        {
            component.AddObserver(this);
            components.Add(component);
            Console.WriteLine("Added component: " + component.Name + " to gameobject: " + this.name);
        }
        /// <summary>
        /// Removes a component from the gameobject
        /// </summary>
        /// <param name="component"></param>
        public void RemoveComponent(Component component)
        {
            components.Remove(component);
        }
        /// <summary>
        /// Returns the first gameobject by type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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
        /// <summary>
        /// Returns the first gameobject by name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public Component GetComponentByName<T>(string name) // name is not unique you could end op just getting the first item with the name
        {
            return components.FirstOrDefault(x => x.Name == name);
        }
        /// <summary>
        /// Returns all gameobjects components
        /// </summary>
        /// <returns></returns>
        public List<Component> GetComponents()
        {
            return components;
        }

        public override string ToString()
        {
            return MyExtensions.ToStringExtension(this);
        }
    }
}
