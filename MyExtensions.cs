using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public static class MyExtensions
    {
        public static string ToStringExtension(this object obj)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var property in obj.GetType().GetFields())
            {
                sb.Append(property.Name);
                sb.Append(": ");
                sb.Append(property.GetValue(obj));
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
