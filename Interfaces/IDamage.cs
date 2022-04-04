using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Interfaces
{
    public interface IDamage
    {
        public void DoDamage(GameObject target);
        public void DoDamage(Health target);
    }
}
