using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Interfaces;
using GameLibrary.ConfigExtensions;
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;

namespace GameLibrary
{
    public class Creature : GameObject, ILootable, IDamage
    {
        protected Shield shield;
        protected Weapon weapon;
        protected IHealthAndArmor Health;
        protected float moveSpeed = 1f;
        public bool IsDead
        {
            get => Health.isDead;
        }

        public Creature(int health, Vector2 pos, string _name) : base(pos, _name)
        {
            Health = new Health(health, this);
            AddComponent((Component)Health);
            weapon = new Weapon("Knuckles", 1);
            LootAndEquipItem(weapon);
        }

        void EquipWeapon(Weapon _weapon)
        {
            weapon = _weapon;
            weapon.AddObserver(this);
        }

        void EquipShield(Shield _shield) // every armor piece add to the total amount, we don't simple set the value equl to the shield amount
        {
            if (shield != null) // for our example we really could just assign the value, but for future extendability it makes sense
            {
                Health.RemoveArmor(shield.ShieldAmount); // armor could be added by several armor pieces hence why we need to remove the armor of the currently equipped shield
            }
            shield = _shield;
            ((Health)this.Health).AddObserver(this);
            Health.AddArmor(shield.ShieldAmount);
        }

        public void EquipItem(Item item) // You must only call equip if you already have looted and added the item to your components, only add existing item in inventory, essentionaly 
        {
            var ItemToEquip = GetComponents().FirstOrDefault(x => x.GetType() == item.GetType() && x.Name == item.Name);

            if (ItemToEquip != null)
            {
                switch (item)
                {
                    case Weapon:
                        EquipWeapon((Weapon)item);
                        break;
                    case Shield:
                        EquipShield((Shield)item);
                        break;
                }
            }
            string log = this.name + " equiped: " + item.Name;
            Tracing.Instance.ts.TraceEvent(TraceEventType.Information, 333, log);
            Console.WriteLine(log);
        }
        public void LootAndEquipItem(Item item) // Must add component before you can equip it
        {
            AddComponent(item);
            EquipItem(item);
        }

        public void Move(Vector2 addMoveVec) // hmmmmm
        {
            position += addMoveVec * moveSpeed;
        }
        public void MoveToPos(Vector2 pos) // hmmmmm
        {
            position = pos;
        }

        public void MoveTowardTarget(Vector2 target)
{
            Move(Vector2.Normalize(target - position)); // the unit vector direction towards the target
        }

        public void MoveUpToTarget(Vector2 target)
        {
            while (!InRange(target))
            {
                Console.WriteLine("MoveUpToTarget" + this.name + " pos: " + position + " target pos: " + target + " distance: " + Vector2.Distance(position, target));
                MoveTowardTarget(target);
            }
        }

        public bool InRange(Vector2 target)
        {
            return weapon.AttackRange > Vector2.Distance(position, target);
        }

        public void DoDamage(GameObject target)
        {
            if (CanAttack(target))
            {
                weapon.DoDamage(target);
            }
        }

        public void DoDamage(Health target)
        {
            if (CanAttack(target.Observer.Update()))
            {
                weapon.DoDamage(target);
            }
        }

        bool CanAttack(GameObject target)
        {
            if (Health.isDead)
            {
                Console.WriteLine("Can't attack while dead");
                return false;
            }
            if (!InRange(target.position))
            {
                Console.WriteLine("Not in range");
                return false;
            }
            return true;
        }

        public void Revive()
        {
            string log = this.GetType().Name + " got revived";
            Tracing.Instance.ts.TraceEvent(TraceEventType.Information, 333, log);
            Console.WriteLine(log);
            Health.FullHealth();
            Health.isDead = false;
        }

        public Item LootItem(GameObject objectThatLoots)
        {
            if (!Health.isDead)
            {
                Console.WriteLine("Cannot loot creature while he is stil kicking");
                return null;
            }

            string log = "Looting: " + weapon.Name;
            Tracing.Instance.ts.TraceEvent(TraceEventType.Information, 333, log);
            Console.WriteLine(log);
            objectThatLoots.AddComponent(weapon);
            return weapon;
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
