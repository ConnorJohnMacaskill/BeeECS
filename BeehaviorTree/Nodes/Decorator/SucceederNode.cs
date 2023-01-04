using BeeECS.Entities;
using BeehaviorTree.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeehaviorTree.Nodes.Decorator
{
    public class SucceederNode : DecoratorNode
    {
        public SucceederNode(INode child) : base(child)
        {
        }

        public override State Update(Entity entity)
        {
            State result = Child.Update(entity);

            if (result != State.Running)
            {
                return State.Success;
            }

            return State.Running;
        }
    }
}