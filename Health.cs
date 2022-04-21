using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Interfaces;
using GameLibrary.ConfigExtensions;
using System.Numerics;

namespace GameLibrary
{
    public class Health : Component, IHealthAndArmor 
    {
        /// <summary>
        /// Health has both hitpoints and armor and subracts received damage based upon the amount of armor
        /// </summary>
        public int MaxHealth { get; set; }
        public int health { get; set; }
        public int armor { get; set; }
        public bool isDead { get; set; }

        public Health(int maxHealth = 0, IObserver observer = null) : base("Health", observer)
        {
            armor = 0;
            health = MaxHealth = maxHealth;
            isDead = false;
        }

        /// <summary>
        /// Sets current health equal to MaxHealth
        /// </summary>
        public void FullHealth()
        {
            health = MaxHealth;
        }
        /// <summary>
        /// Adds armor
        /// </summary>
        /// <param name="_armor"></param>
        public void AddArmor(int _armor)
        {
            Console.WriteLine(armor);
            armor += _armor;

            Console.WriteLine(Observer.Update().name + " got added armor: " + _armor + " now has total of: " + armor);
        }
        /// <summary>
        /// Removes armor
        /// </summary>
        /// <param name="_armor"></param>
        public void RemoveArmor(int _armor)
        {
            armor -= _armor;
        }
        /// <summary>
        /// Health receives damage to health
        /// if health reaches 0 then we call Death()
        /// </summary>
        /// <param name="damage"></param>
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
        /// <summary>
        /// We set isDead to true
        /// </summary>
        void Death()
        {
            string log = Observer?.Update().name + " has died";
            Tracing.Instance.ts.TraceEvent(TraceEventType.Information, 333, log);
            Console.WriteLine(log);
            isDead = true;
        }

        public void Heal(int healAmount)
        {
            health = Math.Min(health + healAmount, MaxHealth);
            Console.WriteLine(Observer.Update().name + " healed " + healAmount + " Health and now have " + health + " life points");
        }
    }
}
