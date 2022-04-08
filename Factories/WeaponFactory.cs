using GameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IDamage Create(WeaponType type)
        {
            if (type == WeaponType.Melee) return new Weapon(RandomGenerator.GenerateName(), RandomGenerator.GenerateDmg());
            if (type == WeaponType.Ranged) return new Weapon(RandomGenerator.GenerateName(), RandomGenerator.GenerateDmg());
            if (type == WeaponType.Magic) return new Weapon(RandomGenerator.GenerateName(), RandomGenerator.GenerateDmg());

            throw new ArgumentException($"WeaponFactory - no class available for weapon type {type}");
        }
    }

    public static class RandomGenerator
    {
        static Random random = new Random();

        public static string GenerateName()
        {
            StringBuilder finalString = new StringBuilder();
            List<string> nameAddj = new List<string>()
            {
                "Dark", "Ashen", "Undying", "Great", "Ultra"
            };
            List<string> name = new List<string>()
            {
                "Sword", "Curved sword", "Long sword", "Saber", "Lance"
            };
            return finalString.Append(nameAddj[random.Next(0, nameAddj.Count)] + " " + name[random.Next(0, name.Count)]).ToString();
        }
        public static int GenerateDmg()
        {
            int randomChance = random.Next(0, 20);
            if (randomChance == 1)
            {
                return random.Next(4, 6);
            }
            else
            {
                return random.Next(1, 4);
            }
        }
    }
}
