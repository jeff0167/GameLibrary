using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Weapon : Item, IDamage, ILootable
    {
        protected int Damage { get; set; }
        public Weapon(string name, int _damage) : base(name)
        {
            Damage = _damage;
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
            if (hp == null)
            {
                Console.WriteLine("No health component found");
            }
            else
                hp.ReceiveDamage(Damage);
        }
    }
}
