using System;
using System.Collections.Generic;
using System.Text;
using BeeECS.Entities;
using BeehaviorTree.Enums;

namespace BeehaviorTree.Nodes.Decorator
{
    public class RepeaterNode : DecoratorNode
    {
        private int counter;
        private int numberOfLoops;
        private bool returnOnFailure;

        public RepeaterNode(INode child, int numberOfLoops, bool returnOnFailure) : base(child)
        {
            counter = 0;
            this.numberOfLoops = numberOfLoops;
            this.returnOnFailure = returnOnFailure;
        }

        public override State Update(Entity entity)
        {
            //Repeat until the loops are up or the child returns failure.
            //-1 = infinite.
            State result = Child.Update(entity);

            if(result != State.Running)
            {
                if (numberOfLoops > 0)
                {
                    counter += 1;

                    if (counter == numberOfLoops)
                    {
                        return State.Success;
                    }
                }

                if(result == State.Failure && returnOnFailure)
                {
                    return State.Success;
                }
            }

            return State.Running;
        }

        public override void Reset()
        {
            counter = 0;

            base.Reset();
        }
    }
}
