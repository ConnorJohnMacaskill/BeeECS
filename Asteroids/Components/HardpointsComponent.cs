using BeeECS.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Components
{
    class HardpointsComponent : IComponent
    {
        public List<Hardpoint> Hardpoints { get; set; }
    }

    class Hardpoint
    {
        public Vector2 Offset { get; set; }
        public int EntityID { get; set; }
    }
}
