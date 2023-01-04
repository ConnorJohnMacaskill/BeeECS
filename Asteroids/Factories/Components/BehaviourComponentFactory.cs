using Asteroids.Components;
using BeeECS.Components;
using BeeECS.Factories;
using BeehaviorTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Asteroids.Factories.Components
{
    class BehaviourComponentFactory : IComponentFactory
    {
        public IComponent CreateComponent(XElement componentData)
        {
            string rawTree = componentData.Element("Path").Value;

            BehaviorTree tree = ValueFactory.GetBehaviourTree(rawTree, true);

            return new BehaviourComponent()
            {
                Tree = tree
            };
        }
    }
}
