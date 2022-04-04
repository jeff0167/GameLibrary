using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Interfaces;

namespace GameLibrary
{
    public class StandardPlayerChar : GameObject, IHitable, IDamage
    {
        Health health;
        Weapon sword;

        public bool IsDead { get => health.isDead; }
        public StandardPlayerChar(Vector2 pos, string _name) : base(pos, _name)
        {
            health = new Health(10);
            sword = new Weapon("Short sword", 2);
            components.Add(health);
            components.Add(sword);
        }

        public void Move(Vector2 addMoveVec) // hmmmmm
        {
            position += addMoveVec;
        }
        public void MoveToPos(Vector2 pos) // hmmmmm
        {
            position = pos;
        }

        public void ReceiveDamage(int damage)
        {
            health.ReceiveDamage(damage);
        }

        public void DoDamage(GameObject target)
        {
            sword.DoDamage(target);
        }

        public void DoDamage(Health target)
        {
            sword.DoDamage(target);
        }

        // may want a standard creature that has health and movement and then inherit from it
    }
}
