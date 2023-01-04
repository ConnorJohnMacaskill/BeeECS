using Asteroids.Components;
using BeeECS.Components;
using BeeECS.Factories;
using System.Xml.Linq;

namespace Asteroids.Factories.Components
{
    class TargetComponentFactory : IComponentFactory
    {
        public IComponent CreateComponent(XElement componentData)
        {
            string rawRange = componentData.Element("Range").Value;
            int range = ValueFactory.GetInt(rawRange, true);

            return new TargetComponent()
            {
                TargetID = -1,
                Range = range
            };

        }
    }
}
