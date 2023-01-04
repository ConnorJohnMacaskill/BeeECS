using BeeECS.Entities;
using BeehaviorTree.Enums;

namespace BeehaviorTree.Nodes.Decorator
{
    public abstract class DecoratorNode : INode
    {
        public INode Child { get; set; }

        public DecoratorNode(INode child)
        {
            Child = child;
        }

        public abstract State Update(Entity entity);

        public virtual void Reset()
        {
            Child.Reset();
        }
    }
}
