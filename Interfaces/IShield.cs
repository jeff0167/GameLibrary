using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Interfaces
{
    public interface IShield // how do we make sure that this amount is taken into account when dealing dmg?
    {
        public int ShieldAmount { get; set; }
    }
}
