using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class SceneWorld
    {
        List<GameObject> Hierarchy { get; set; } // all gameobjects in scene, anything that exist in the game is in here
        public SceneWorld(GameConfigurations configurations) // the first thing we will create, this will be responsable for the entire game 
        {
            Hierarchy = new List<GameObject>();   // so it is the one that should be given the configurations to set up the game
        }
        public void AddGameObject(GameObject gameObject)
        {
            Hierarchy.Add(gameObject);
        }
        public GameObject FindObjectByName(string name)
        {
            return Hierarchy.FirstOrDefault(x => x.name == name);
        } 
        public GameObject FindObjectByTag(string tag)
        {
            return Hierarchy.FirstOrDefault(x => x.tag == tag);
        }

        public void Play() // we are ready to start the game
        {

        }

        public void Reload()
        {

        }


        // when ever a gameobject is destroyed it should be removed from the hiearchy which is observing all gameobjects
        // maybe we could make the components attached thingy to gameobjects, components should not exist without a gameobject
        // the component something pattern thingy
    }
}
