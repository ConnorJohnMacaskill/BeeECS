using BeeECS.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Components
{
    class HealthComponent : IComponent
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
    }
}
