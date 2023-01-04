using BeeECS.Components;
using BeehaviorTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Components
{
    class BehaviourComponent : IComponent
    {
        public BehaviorTree Tree { get; set; }
    }
}
