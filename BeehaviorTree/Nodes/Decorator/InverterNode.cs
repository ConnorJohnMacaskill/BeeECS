using System;
using System.Collections.Generic;
using System.Text;
using BeeECS.Entities;
using BeehaviorTree.Enums;

namespace BeehaviorTree.Nodes.Decorator
{
    public class InverterNode : DecoratorNode
    {
        public InverterNode(INode child) : base(child)
        {
        }

        public override State Update(Entity entity)
        {
            State result = Child.Update(entity);

            if(result == State.Success)
            {
                return State.Failure;
            }
            else if(result == State.Failure)
            {
                return State.Success;
            }

            return State.Running;
        }
    }
}
