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
        /// <summary>
        /// Creature Inherits from gameobject
        /// The minimal simple framework for constructing a moving and fighting living being
        /// Easily extendable to add new features
        /// Can attack, take damage, equip and loot, and move around
        /// </summary>
        protected Shield shield;
        protected Weapon weapon;
        protected IHealthAndArmor Health;
        protected float moveSpeed = 1f;
        public bool IsDead
        {
            get => Health.isDead;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="health"> A health component</param>
        /// <param name="pos"> A vector2</param>
        /// <param name="_name"> A simple name for our creature</param>
        public Creature(int health, Vector2 pos, string _name) : base(pos, _name) // think I should be able to inject weapons now
        {
            Health = new Health(health, this);
            AddComponent((Component)Health);
            weapon = new Weapon("Knuckles", 1);
            LootAndEquipItem(weapon);
        }
        /// <summary>
        /// Creature has one weapon only which we asign to and we assign this gameobject to the weapon 
        /// so the weapon knows who it belongs to
        /// </summary>
        /// <param name="_weapon"></param>
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

        /// <summary>
        /// We loot an item, add it as a component and then we equip it
        /// </summary>
        /// <param name="item"></param>
        public void LootAndEquipItem(Item item) // Must add component before you can equip it
        {
            AddComponent(item);
            EquipItem(item);
        }

        /// <summary>
        /// We move by a adding some vector2 to our current pos/vector2
        /// </summary>
        /// <param name="addMoveVec"></param>
        public void Move(Vector2 addMoveVec) // hmmmmm
        {
            position += addMoveVec * moveSpeed;
        }
        public void MoveToPos(Vector2 pos) // hmmmmm
        {
            position = pos;
        }
        /// <summary>
        /// We move directly toward the target
        /// </summary>
        /// <param name="target"></param>
        public void MoveTowardTarget(Vector2 target)
        {
            Move(Vector2.Normalize(target - position)); // the unit vector direction towards the target
        }
        /// <summary>
        /// We move towards the target until we are in attack range of them
        /// </summary>
        /// <param name="target"></param>
        public void MoveUpToTarget(Vector2 target)
        {
            while (!InRange(target))
            {
                Console.WriteLine("MoveUpToTarget" + this.name + " pos: " + position + " target pos: " + target + " distance: " + Vector2.Distance(position, target));
                MoveTowardTarget(target);
            }
        }

        /// <summary>
        /// We check if we are in attack range of a target
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool InRange(Vector2 target)
        {
            return weapon.AttackRange > Vector2.Distance(position, target);
        }

        /// <summary>
        /// Deals damage to target going through a gameobject
        /// </summary>
        /// <param name="target"></param>
        public void DoDamage(GameObject target)
        {
            if (CanAttack(target))
            {
                weapon.DoDamage(target);
            }
        }
        /// <summary>
        /// Deals damage to target going through a health component directly to the source
        /// </summary>
        /// <param name="target"></param>
        public void DoDamage(Health target)
        {
            if (CanAttack(target.Observer.Update()))
            {
                weapon.DoDamage(target);
            }
        }
        /// <summary>
        /// We check if we can attack the target
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Revives creature to max health
        /// </summary>
        public void Revive()
        {
            string log = this.GetType().Name + " got revived";
            Tracing.Instance.ts.TraceEvent(TraceEventType.Information, 333, log);
            Console.WriteLine(log);
            Health.FullHealth();
            Health.isDead = false;
        }
        /// <summary>
        /// Simply loots the weapon of the creature if they are dead
        /// </summary>
        /// <param name="objectThatLoots"> We send the gameobject that will be given the component/weapon</param>
        /// <returns></returns>
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
        /// <summary>
        /// Generates and loots random item
        /// </summary>
        /// <param name="objectThatLoots"></param>
        /// <returns></returns>
        public Item LootRandomGeneratedItem(GameObject objectThatLoots)
        {
            if (!Health.isDead)
            {
                Console.WriteLine("Cannot loot creature while he is stil kicking");
                return null;
            }
            IWeaponFactory factory = new Factories.WeaponFactory();

            Item item = (Item)factory.Create(WeaponType.Melee);
            objectThatLoots.AddComponent(item);

            string log = "Looting: " + item.Name;
            Tracing.Instance.ts.TraceEvent(TraceEventType.Information, 333, log);
            Console.WriteLine(log);
            return item;
        }
        /// <summary>
        /// Creature takes damage to health
        /// </summary>
        /// <param name="damage"></param>
        public void ReceiveDamage(int damage)
        {
            if (IsDead)
            {
                Console.WriteLine("They are dead, don't beat a dead horse");
                return;
            }
            Health.ReceiveDamage(damage);
        }
    }
}
