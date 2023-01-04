using Asteroids.Components;
using BeeECS.Entities;
using BeeECS.Managers;
using BeehaviorTree.Enums;
using BeehaviorTree.Nodes;
using System;

namespace Asteroids.Behaviour
{
    class RotateTowardsTargetNode : INode
    {
        public State Update(Entity entity)
        {
            TargetComponent targetComponent = entity.GetComponent<TargetComponent>();

            if(targetComponent?.Target != null)
            {
                Entity target = targetComponent.Target;
                float angle = (float)Math.Atan2(target.Transform.Position.Y - entity.Transform.Position.Y, target.Transform.Position.X - entity.Transform.Position.X);

                float rotationDiff = entity.Transform.Rotation - angle;

                if(Math.Abs(rotationDiff) > 3.14159f)
                {
                    rotationDiff += rotationDiff > 0 ? -6.28319f : 6.28319f;
                }

                if(Math.Abs(rotationDiff) < 0.1f)
                {
                    entity.Transform.Rotation = angle;
                }
                else if(rotationDiff < 0)
                {
                    entity.Transform.Rotation += 0.1f;
                }
                else if(rotationDiff > 0)
                {
                    entity.Transform.Rotation -= 0.1f;
                }

      
                return State.Success;
            }
            else
            {
                return State.Failure;
            }
        }

        public void Reset()
        {
            //Nothing to do!
        }
    }
}
