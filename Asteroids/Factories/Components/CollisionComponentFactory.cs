using Asteroids.Components;
using BeeECS.Components;
using BeeECS.Factories;
using Logging;
using Logging.Enums;
using System.Xml.Linq;

namespace Asteroids.Factories.Components
{
    class CollisionComponentFactory : IComponentFactory
    {
        public IComponent CreateComponent(XElement componentData)
        {
            string rawClass = componentData.Element("Class").Value;
            string rawRadius = componentData.Element("Radius").Value;

            int radius = ValueFactory.GetInt(rawRadius, true);

            return new CollisionComponent()
            {
                Class = rawClass,
                Radius = radius,
                SecondsToLive = -1
            };
        }
    }
}
