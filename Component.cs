using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public abstract class Component
    {
        public string Name { get; }

        protected Component(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            Console.WriteLine(MyExtensions.ToStringExtension(this));
            return "";
        }
    }
}
