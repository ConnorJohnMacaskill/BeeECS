using BeeECS.Entities;
using BeehaviorTree.Enums;
using System.Collections.Generic;
using System.Linq;

namespace BeehaviorTree.Nodes.Composite
{
    public class ParallelNode : CompositeNode
    {
        private int successCounter;
        private int failureCounter;
        private int succesesToSucceed;
        private int failuresToFail;
        private List<INode> childrenToRun;

        public ParallelNode(INode[] children, int succesesToSucceed, int failuresToFail) : base(children)
        {
            //We are iterating over our children backwards here so we need to reverse our children.
            Children = children.Reverse().ToArray();
            childrenToRun = children.ToList();

            this.succesesToSucceed = succesesToSucceed;
            this.failuresToFail = failuresToFail;
        }

        public override State Update(Entity entity)
        {
            for(int i = childrenToRun.Count -1; i >= 0; i--)
            {
                State result = childrenToRun[i].Update(entity);
                
                if(result != State.Running)
                {
                    childrenToRun.RemoveAt(i);
                    
                    if(result == State.Success)
                    {
                        successCounter += 1;
                    }
                    else if(result == State.Failure)
                    {
                        failureCounter += 1;
                    }
                }

                if (successCounter >= succesesToSucceed)
                {
                    return State.Success;
                }

                if (failureCounter >= failuresToFail)
                {
                    return State.Failure;
                }
            }

            return State.Running;
        }

        public override void Reset()
        {
            childrenToRun = Children.ToList();
            successCounter = 0;
            failureCounter = 0;

            base.Reset();
        }
    }
}
