using Asteroids.Components;
using BeeECS.Entities;
using BeehaviorTree.Enums;
using BeehaviorTree.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Behaviour
{
    class CheckHasTargetNode : INode
    {

        public CheckHasTargetNode()
        {
        }

        public State Update(Entity entity)
        {
            TargetComponent targetComponent = entity.GetComponent<TargetComponent>();

            if (targetComponent?.Target != null)
            {
                return State.Success;
            }

            return State.Failure;
        }

        public void Reset()
        {

        }
    }
}
