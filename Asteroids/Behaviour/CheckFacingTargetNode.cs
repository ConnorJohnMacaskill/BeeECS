using Asteroids.Components;
using BeeECS.Entities;
using BeehaviorTree.Enums;
using BeehaviorTree.Nodes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Behaviour
{
    class CheckFacingTargetNode : INode
    {
        private float tolerence;

        public CheckFacingTargetNode(float tolerence)
        {
            this.tolerence = tolerence;
        }

        public State Update(Entity entity)
        {
            TargetComponent targetComponent = entity.GetComponent<TargetComponent>();

            if(targetComponent?.Target != null)
            {
                Entity target = targetComponent.Target;
                float angle = (float)Math.Atan2(target.Transform.Position.Y - entity.Transform.Position.Y, target.Transform.Position.X - entity.Transform.Position.X);

                float difference = Math.Abs(MathHelper.WrapAngle(angle - entity.Transform.Rotation));

                if(difference <= tolerence)
                {
                    return State.Success;
                }
            }

            return State.Failure;
        }

        public void Reset()
        {

        }
    }
}
