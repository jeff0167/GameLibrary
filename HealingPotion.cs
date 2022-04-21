using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    /// <summary>
    /// Healing potions heals target by a chosen amount
    /// </summary>
    public class HealingPotion : Potion
    {
        public int HealingAmount { get; set; }

        public HealingPotion(int healingAmount)
        {
            HealingAmount = healingAmount;
        }

        public override void Consume(Creature creature)
        {
            creature.Heal(HealingAmount);
        }
    }
}
