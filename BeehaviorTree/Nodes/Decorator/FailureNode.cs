using BeeECS.Entities;
using BeehaviorTree.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeehaviorTree.Nodes.Decorator
{
    public class FailureNode : DecoratorNode
    {
        public FailureNode(INode child) : base(child)
        {
        }

        public override State Update(Entity entity)
        {
            State result = Child.Update(entity);

            if (result != State.Running)
            {
                return State.Failure;
            }

            return State.Running;
        }
    }
}