using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Interfaces
{
    public interface IHitable
    {
        public void ReceiveDamage(int damage);
        public void FullHealth();
        public void Heal(int healAmount);

        public int MaxHealth { get; set; } // should have both lootable and hitable

        public int health { get; set; }

        public bool isDead { get; set; }

        public void RemoveArmor(int shieldAmount);
        public void AddArmor(int shieldAmount);
    }
}
