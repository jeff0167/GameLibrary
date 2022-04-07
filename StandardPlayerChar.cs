using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Interfaces;

namespace GameLibrary
{
    public class StandardPlayerChar : Creature
    {
        public StandardPlayerChar(int health, Vector2 pos, string _name) : base(health, pos, _name) // how is this any different from player!?!?
        {
            RemoveComponent(GetComponent<Weapon>()); // hmmm
            weapon = new Weapon("Short sword", 2);
            LootAndEquipItem(weapon);
        }
    }
}
