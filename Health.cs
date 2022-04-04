using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Interfaces;

namespace GameLibrary
{
    public class Health : Component, IHitable // now objects that dont really need health but can be hit can also use the same function
    {
        public int MaxHealth { get; set; } // should have both lootable and hitable
        public int health { get; set; }

        public bool isDead;

        public Health(int maxHealth = 0) : base("Health")
        {
            health = MaxHealth = maxHealth;       
            isDead = false;
        }

        public void FullHealth()
        {
            health = MaxHealth;
        }
        public void ReceiveDamage(int damage)
        {
            if (isDead) return;
            health-=damage;

            Console.WriteLine("Took damage, have life left: " + health);
            if(health <= 0)
            {
                Death();
            }
        }

        void Death()
        {
            Console.WriteLine("Died");
            isDead = true;
        }
    }
}
