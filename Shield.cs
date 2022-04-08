using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Interfaces;

namespace GameLibrary
{
    public class Shield : Item, IShield
    {
        /// <summary>
        /// Shield adds armor and decrease damage taken
        /// </summary>
        public int ShieldAmount { get; set; }
        public Shield(string name, int shieldAmount) : base(name)
        {
            ShieldAmount = shieldAmount;
        }
    }
}
