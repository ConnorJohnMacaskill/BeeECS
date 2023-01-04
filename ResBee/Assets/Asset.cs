using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResBee.Assets
{
    public abstract class Asset
    {
        public Asset(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
