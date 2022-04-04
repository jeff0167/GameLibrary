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
        protected Item(string name) : base(name)
        {
        }

        public void LootItem(GameObject objectThatLoots)
        {
            objectThatLoots.AddComponent(this);
        }
    }
}
