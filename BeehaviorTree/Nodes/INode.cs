using BeeECS.Entities;
using BeehaviorTree.Enums;

namespace BeehaviorTree.Nodes
{
    public interface INode
    {
        State Update(Entity entity);

        void Reset();
    }
}
