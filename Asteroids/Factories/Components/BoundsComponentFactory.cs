using Asteroids.Components;
using BeeECS.Components;
using BeeECS.Factories;
using System.Xml.Linq;

namespace Asteroids.Factories.Components
{
    class BoundsComponentFactory : IComponentFactory
    {
        public IComponent CreateComponent(XElement componentData)
        {
            return new BoundsComponent();
        }
    }
}