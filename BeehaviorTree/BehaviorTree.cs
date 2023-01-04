using BeeECS.Entities;
using BeehaviorTree.Enums;
using BeehaviorTree.Nodes;

namespace BeehaviorTree
{
    public class BehaviorTree
    {
        private INode root;

        public BehaviorTree(INode root)
        {
            this.root = root;
        }

        public void Update(Entity entity)
        {
            State result = root.Update(entity);

            if(result != State.Running)
            {
                root.Reset();
            }
        }

        //Tree containts the current node and the root node.
        //Tree should reset after each complete Tick.
        //Tree ticks nodes, if a node returns Running it stores it for the next tick?
        //Pass the running back up the tree? If the root node returns true or false then reset.
        //Pass the currently running node back up the tree? (future optimistion).
        
    }
}
