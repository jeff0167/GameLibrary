using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public interface ILootable
    {
        void LootItem(GameObject objectThatLoots);
    }

    public interface IRemovable
    {
        GameObject RemoveItem();
    }

    public interface IDamage
    {
        public void DoDamage(GameObject target);
        public void DoDamage(Health target);
    }

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
