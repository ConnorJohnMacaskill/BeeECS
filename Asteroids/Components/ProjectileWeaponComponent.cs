using BeeECS.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Asteroids.Components
{
    public sealed class ProjectileWeaponComponent : IComponent
    {
        public int ProjectilesPerShot { get; set; }
        public double BurstDelayInSeconds { get; set; }
        public double SecondsPerShot { get; set; }
        public double Timer { get; set; }
        public bool Firing { get; set; }
    }
}
