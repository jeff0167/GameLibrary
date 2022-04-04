using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Interfaces;

namespace GameLibrary
{
    public class Creature : GameObject, ILootable, IDamage
    {
        Weapon weapon;
        Health Health;
        public bool IsDead
        {
            get => Health.isDead;
        }

        public Creature(int health, Vector2 pos, string _name) : base(pos, _name)
        {
            Health = new Health(health);
            components.Add(Health);
            weapon = new Weapon("Halberd0", 2);
            components.Add(weapon);
        }

        public void Attack(GameObject target)
        {
            weapon.DoDamage(target);
        }

        public void DoDamage(GameObject target)
        {
            weapon.DoDamage(target);
        }

        public void DoDamage(Health target)
        {
            weapon.DoDamage(target);
        }

        public void LootItem(GameObject objectThatLoots)
        {
            if (!Health.isDead)
            {
                Console.WriteLine("Cannot loot creature while he is stil kicking");
                return;
            }
            Console.WriteLine("Looting: " + weapon.Name);
            objectThatLoots.AddComponent(weapon);
        }
        public void ReceiveDamage(int damage)
        {
            Health.ReceiveDamage(damage);
        }
    }
}
