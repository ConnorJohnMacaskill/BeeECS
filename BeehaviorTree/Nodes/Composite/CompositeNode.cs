using BeeECS.Entities;
using BeehaviorTree.Enums;

namespace BeehaviorTree.Nodes.Composite
{
    public abstract class CompositeNode : INode
    {
        public INode[] Children { get; set; }

        public CompositeNode(INode[] children)
        {
            Children = children;
        }

        public abstract State Update(Entity entity);

        public virtual void Reset()
        {
            for(int i = 0; i < Children.Length; i++)
            {
                Children[i].Reset();
            }
        }
    }
}
