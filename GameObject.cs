using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GameLibrary
{
    public class GameObject
    {
        public string name;
        public string tag;   // technically the parent gameobject has the tag
        public int id;
        public Vector2 position;
        public List<Component> components; // could we make the sceneworld observe the ctor and add it?

        public GameObject(Vector2 pos, string _name)
        {
            name = _name;
            position = pos;
            components = new List<Component>();
        }

        public void AddComponent(Component component)
        {
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
