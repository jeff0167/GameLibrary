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
    public class Health : Component, IHealthAndArmor // now objects that dont really need health but can be hit can also use the same function
    {
        public int MaxHealth { get; set; } // should have both lootable and hitable
        public int health { get; set; }

        public int armor { get; set; }

        public bool isDead { get; set; }

        public Health(int maxHealth = 0, IObserver observer = null) : base("Health", observer)
        {
            armor = 0;
            health = MaxHealth = maxHealth;
            isDead = false;
        }

        public void FullHealth()
        {
            health = MaxHealth;
        }

        public void AddArmor(int _armor)
        {
            Console.WriteLine(armor);
            armor += _armor;

            Console.WriteLine(Observer.Update().name + " got added armor: " + _armor + " now has total of: " + armor);
        }
        public void RemoveArmor(int _armor)
        {
            armor -= _armor;
        }
        public void ReceiveDamage(int damage)
        {
            if (isDead) return;
            int actualDamage = Math.Clamp(damage - armor, 0, int.MaxValue);
            health -= actualDamage;

            string log = Observer?.Update().name + " Took " + actualDamage + " damage, have " + health + " life left";
            Tracing.Instance.ts.TraceEvent(TraceEventType.Information, 333, log);
            Console.WriteLine(log);
            if (health <= 0)
            {
                Death();
            }
        }

        void Death()
        {
            string log = Observer?.Update().name + " has died";
            Tracing.Instance.ts.TraceEvent(TraceEventType.Information, 333, log);
            Console.WriteLine(log);
            isDead = true;
        }
    }
}
