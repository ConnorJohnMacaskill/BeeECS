using Asteroids.Components;
using BeeECS.Components;
using BeeECS.Factories;
using Logging;
using Logging.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Xml.Linq;

namespace Asteroids.Factories.Components
{
    public class SpinComponentFactory : IComponentFactory
    {
        private static Random rand = new Random();

        public IComponent CreateComponent(XElement componentData)
        {
            string rawDegreesPerSecond = componentData.Element("DegreesPerSecond")?.Value;

            float degreesPerSecond = ValueFactory.GetFloat(rawDegreesPerSecond, true);

            SpinComponent rotateComponent = new SpinComponent()
            {
                //Rotation is measured in radians internally.
                RadiansPerSecond = MathHelper.ToRadians(degreesPerSecond)
            };

            return rotateComponent;
        }
    }
}
