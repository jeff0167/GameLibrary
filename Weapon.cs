using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Interfaces;

namespace GameLibrary
{
    public class Weapon : Item, IDamage
    {
        Random Random = new Random();
        public float AttackRange;
        public int Damage; // can't show protected values in tostring   also props with  {get;set;}  don't show up either, needs fix
        public Weapon(string name, int _damage, float attackRange = 5) : base(name)
        {
            Damage = _damage;
            AttackRange = attackRange;
        }

        public void DoDamage(Health hp)
        {
            DealingDmg(hp);
        }

        public void DoDamage(GameObject target)
        {
            Health hp = target.GetComponent<Health>();
            DealingDmg(hp);
        }

        void DealingDmg(Health hp)
        {
            Console.WriteLine(Observer?.Update().name + " is trying to attack"); // dont get the orc name
            if (hp == null)
            {
                Console.WriteLine("No health component found");
            }
            else
                hp.ReceiveDamage(CritChance());
        }

        int CritChance()
        {
            if (Random.Next(0, 10) == 1)
            {
                Console.WriteLine("CRITICAL HIT");
                return Random.Next(Damage + 1, Damage + 2);
            }
            return Damage;
        }
    }
}
