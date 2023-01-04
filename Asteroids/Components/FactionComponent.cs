using BeeECS.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Components
{
    class FactionComponent : IComponent
    {
        public int FactionID { get; set; }
    }
}
