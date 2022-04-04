using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Interfaces;
using GameLibrary.ConfigExtensions;

namespace GameLibrary
{
    public abstract class Creature : GameObject, ILootable, IDamage
    {
        protected Weapon weapon;
        protected Health Health;
        public bool IsDead
        {
            get => Health.isDead;
        }

        public Creature(int health, Vector2 pos, string _name) : base(pos, _name)
        {
            Health = new Health(health);
            components.Add(Health);
            weapon = new Weapon("Knuckles", 0);
            components.Add(weapon);
        }

        public void Move(Vector2 addMoveVec) // hmmmmm
        {
            position += addMoveVec;
        }
        public void MoveToPos(Vector2 pos) // hmmmmm
        {
            position = pos;
        }

        public void DoDamage(GameObject target)
        {
            if (Health.isDead)
            {
                Console.WriteLine("Can't attack while dead");
                return;
            }
            weapon.DoDamage(target);
        }

        public void DoDamage(Health target)
        {
            if (Health.isDead)
            {
                Console.WriteLine("Can't attack while dead");
                return;
            }
            weapon.DoDamage(target);
        }

        public void LootItem(GameObject objectThatLoots)
        {
            if (!Health.isDead)
            {
                Console.WriteLine("Cannot loot creature while he is stil kicking");
                return;
            }

            string log = "Looting: " + weapon.Name;
            Tracing.Instance.ts.TraceEvent(TraceEventType.Information, 333, log);
            Console.WriteLine(log);
            objectThatLoots.AddComponent(weapon);
        }
        public void ReceiveDamage(int damage)
        {
            if (IsDead)
            {
                Console.WriteLine("He is dead, don't beat a dead horse");
                return;
            }
            Health.ReceiveDamage(damage);
        }
    }
}
