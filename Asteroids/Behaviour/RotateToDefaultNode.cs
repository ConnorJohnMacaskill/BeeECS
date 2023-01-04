using Asteroids.Components;
using BeeECS.Entities;
using BeehaviorTree.Enums;
using BeehaviorTree.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Behaviour
{
    class RotateToDefaultNode : INode
    {
        public State Update(Entity entity)
        {
            /*if (Math.Abs(entity.Transform.Rotation) < 0.1f)
            {
                entity.Transform.Rotation = 0;
            }
            if (entity.Transform.Rotation < 0)
            {
                entity.Transform.Rotation += 0.1f;
            }
            else if (entity.Transform.Rotation > 0)
            {
                entity.Transform.Rotation -= 0.1f;
            }*/

            float rotationDiff = entity.Transform.Rotation - entity.Transform.DefaultRotation;
            //MathHelper.WrapAngle();
            if (Math.Abs(rotationDiff) < 0.1f)
            {
                entity.Transform.Rotation = entity.Transform.DefaultRotation;
            }
            else if (rotationDiff < 0)
            {
                entity.Transform.Rotation += 0.1f;
            }
            else if (rotationDiff > 0)
            {
                entity.Transform.Rotation -= 0.1f;
            }

            return State.Success;
        }

        public void Reset()
        {
            //Nothing to do!
        }
    }
}
