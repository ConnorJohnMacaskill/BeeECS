using ECS.Base.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Asteroids.Components
{
    sealed class WeaponComponent : IComponent
    {
        public double SecondsPerShot { get; set; }
        public double Timer { get; set; }
        public bool Fire { get; set; }

        public IComponent Load(XElement componentElement)
        {
            return new WeaponComponent();
        }
    }
}
