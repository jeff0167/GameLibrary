using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class GameConfigurations
    {
        static GameConfigurations instance;

        protected GameConfigurations Instance()
        {
            if(instance == null) instance = new GameConfigurations();
            return instance;
        }
    }
}
