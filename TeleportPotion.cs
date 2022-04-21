using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    /// <summary>
    /// Teleportation potions teleport you to random positions out of danger hopefully
    /// </summary>
    public class TeleportPotion : Potion
    {
        Random random = new Random();

        public TeleportPotion()
        {
        }

        public override void Consume(Creature creature)
        {
            Vector2 newPos = new Vector2((float)random.NextDouble() * 100, (float)random.NextDouble() * 100);
            Console.WriteLine(creature.name + " got teleportet to a random position and is now at " + newPos);
            creature.MoveToPos(newPos);
        }
    }
}
