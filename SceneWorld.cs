using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.ConfigExtensions;

namespace GameLibrary
{
    public class SceneWorld
    {
        /// <summary>
        /// SceneWorld organisez all gameobjects in the scene and keeps track of them
        /// Gameobjects can be searched for in the hiearchy
        /// </summary>
        Tracing trace = Tracing.Instance; // saving ref for tracing instance for future use and less code when used
        List<GameObject> Hierarchy { get; set; } // all gameobjects in scene, anything that exist in the game is in here
        public SceneWorld(GameConfigurations configurations) // the first thing we will create, this will be responsable for the entire game 
        {
            trace.Setup(configurations.GameName, configurations.LogName, configurations.DoLog);
            trace.ts.TraceEvent(TraceEventType.Information, 333, "Game world created");
            Hierarchy = new List<GameObject>();   // so it is the one that should be given the configurations to set up the game
        }
        /// <summary>
        /// Add's gameobject to hiearchy
        /// </summary>
        /// <param name="gameObject"></param>
        public void AddGameObject(GameObject gameObject)
        {
            Hierarchy.Add(gameObject);
        }
        /// <summary>
        /// Finds gameobject by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GameObject FindObjectByName(string name)
        {
            return Hierarchy.FirstOrDefault(x => x.name == name);
        }
        /// <summary>
        /// Finds gameobject by tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public GameObject FindObjectByTag(string tag)
        {
            return Hierarchy.FirstOrDefault(x => x.tag == tag);
        }

        public void Play() // we are ready to start the game
        {
            trace.ts.TraceEvent(TraceEventType.Information, 333, "Game world started");
        }

        public void Reload()
        {
        }

        public void StopGame()
        {
        }
        // when ever a gameobject is destroyed it should be removed from the hiearchy which is observing all gameobjects
        // maybe we could make the components attached thingy to gameobjects, components should not exist without a gameobject
        // the component something pattern thingy
    }
}
