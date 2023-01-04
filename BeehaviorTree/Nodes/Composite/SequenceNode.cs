using BeeECS.Entities;
using BeehaviorTree.Enums;
using BeehaviorTree.Utility;

namespace BeehaviorTree.Nodes.Composite
{
    public class SequenceNode : CompositeNode
    {
        private int currentNodeIndex;
        private bool randomise;

        public SequenceNode(INode[] children, bool randomise) : base(children)
        {
            currentNodeIndex = 0;
            this.randomise = randomise;

            if (randomise)
            {
                children = children.Shuffle();
            }
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
                    return HandleSuccess();
                case State.Failure:

                    return State.Failure;
            }

            return State.Running;
        }

        private State HandleSuccess()
        {
            if (currentNodeIndex == Children.Length - 1)
            {
                return State.Success;
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
