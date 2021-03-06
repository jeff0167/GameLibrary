using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Interfaces;

namespace GameLibrary
{
    public abstract class Item : Component, ILootable
    {
        /// <summary>
        /// A item that can be looted and possibly equiped and used
        /// </summary>
        /// <param name="name"></param>
        protected Item(string name) : base(name)
        {
        }

        public Item LootItem(GameObject objectThatLoots)
        {
            objectThatLoots.AddComponent(this);
            return this;
        }
    }
}
