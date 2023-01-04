using BeeECS.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Asteroids.Components
{
    sealed class CollisionComponent : IComponent
    {
        public CollisionComponent()
        {

        }

        public int Radius { get; set; }
        public string Class { get; set; }
        public bool Collided { get; set; }
        public double SecondsToLive { get; set; }
    }
}
