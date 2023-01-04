using Asteroids.Components;
using BeeECS.Components;
using BeeECS.Factories;
using Logging;
using Logging.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Asteroids.Factories.Components
{
    class ProjectileWeaponComponentFactory : IComponentFactory
    {
        public IComponent CreateComponent(XElement componentData)
        {
            string rawShotsPerSecond = componentData.Element("SecondsPerShot").Value;
            double secondsPerShot = ValueFactory.GetDouble(rawShotsPerSecond, true);

            return new ProjectileWeaponComponent()
            {
                SecondsPerShot = secondsPerShot,
                Timer = 0
            };
        }
    }
}
