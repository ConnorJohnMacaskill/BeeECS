using BeeECS.Entities;
using BeehaviorTree.Enums;
using BeehaviorTree.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeehaviorTree.Nodes.Composite
{
    public class SelectorNode : CompositeNode
    {
        private int currentNodeIndex;
        private bool randomise;

        public SelectorNode(INode[] children, bool randomise) : base(children)
        {
            currentNodeIndex = 0;
            this.randomise = randomise;
        }

        private INode CurrentNode
        {
            get
            {
                return Children[currentNodeIndex];
            }
        }

        public override State Update(Entity entity)
        {
            INode currentNode = CurrentNode;

            State state = currentNode.Update(entity);

            switch (state)
            {
                case State.Running:
                    return State.Running;
                case State.Success:
                    return State.Success;
                case State.Failure:
                    return HandleFailure();
            }

            return State.Running;
        }

        private State HandleFailure()
        {
            if (currentNodeIndex == Children.Length - 1)
            {
                return State.Failure;
            }
            else
            {
                //Else increment the counter so can begin updating the next node.
                currentNodeIndex += 1;
            }

            return State.Running;
        }

        public override void Reset()
        {
            if (randomise)
            {
                Children = Children.Shuffle();
            }

            currentNodeIndex = 0;
            base.Reset();
        }
    }
}
