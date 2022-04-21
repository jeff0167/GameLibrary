using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Interfaces;

namespace GameLibrary
{
    /// <summary>
    /// potions are consumable and can give a varierty of effects, destroyed upon use 
    /// </summary>
    public abstract class Potion : IConsumable
    {
        public abstract void Consume(Creature creature); // how in the world do we destory stuff, sure we could make a bool that just check if the potion is still consumable
    }
}
