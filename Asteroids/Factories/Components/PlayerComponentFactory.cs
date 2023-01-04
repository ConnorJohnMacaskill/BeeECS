using Asteroids.Components;
using BeeECS.Components;
using BeeECS.Factories;
using System;
using System.Xml.Linq;

namespace Asteroids.Factories.Components
{
    class PlayerComponentFactory : IComponentFactory
    {
        public IComponent CreateComponent(XElement componentData)
        {
            return new PlayerComponent();
        }
    }
}
