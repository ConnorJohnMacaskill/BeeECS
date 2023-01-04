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
    public class MovementComponentFactory : IComponentFactory
    {
        public IComponent CreateComponent(XElement componentData)
        {
            Random rand = new Random();

            string rawAccelerationPerSecond = componentData.Element("AccelerationPerSecond").Value;
            string rawMaxSpeed = componentData.Element("MaxSpeed").Value;
            string rawDegreesPerSecond = componentData.Element("DegreesPerSecond").Value;
            string rawSpeedPerSecond = componentData.Element("SpeedPerSecond")?.Value;

            float accelerationPerSecond = ValueFactory.GetFloat(rawAccelerationPerSecond, true);
            float maxSpeed = ValueFactory.GetFloat(rawMaxSpeed, true);
            float degreesPerSecond = ValueFactory.GetFloat(rawDegreesPerSecond, false);
            float speedPerSecond = ValueFactory.GetFloat(rawSpeedPerSecond, false);

            return new MovementComponent()
            {
                AccelerationPerSecond = accelerationPerSecond,
                MaxSpeed = maxSpeed,
                RadiansPerSecond = MathHelper.ToRadians(degreesPerSecond),
                Speed = speedPerSecond
            };
        }
    }
}
