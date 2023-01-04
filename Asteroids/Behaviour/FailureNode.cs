using BeeECS.Entities;
using BeehaviorTree.Enums;
using BeehaviorTree.Nodes;

namespace Asteroids.Behaviour
{
    class FailureNode : INode
    {
        public State Update(Entity entity)
        {
            return State.Failure;
        }

        public void Reset()
        {
        }
    }
}
