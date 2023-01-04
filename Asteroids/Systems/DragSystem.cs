using Asteroids.Components;
using BeeECS.Entities;
using BeeECS.Managers;
using BeeECS.Systems;
using Microsoft.Xna.Framework;
using System;

namespace Asteroids.Systems
{
    public sealed class DragSystem : ECSystem, IUpdatableSystem
    {
        public DragSystem()
        {
            Enabled = true;
            
            Requirements = new SystemRequirements();
            Requirements.AddRequirement<MovementComponent>();
            Requirements.AddRequirement<DragComponent>();
        }

        public override SystemRequirements Requirements { get; set; }

        public void Update(GameTime gameTime)
        {
            foreach (Entity entity in Entities)
            {
                MovementComponent movementComponent = ComponentManager.Instance.GetComponent<MovementComponent>(entity);
                DragComponent dragComponent = ComponentManager.Instance.GetComponent<DragComponent>(entity);

                float movementDrag = (float)(dragComponent.MovementDrag * gameTime.ElapsedGameTime.TotalSeconds);

                if(Math.Abs(movementComponent.Speed) < movementDrag)
                {
                    movementComponent.Speed = 0;
                }

                if (movementComponent.Speed > 0)
                {
                    movementComponent.Speed -= movementDrag;
                }
                else if(movementComponent.Speed < 0)
                {
                    movementComponent.Speed += movementDrag;
                }

                float rotationDrag = (float)(dragComponent.RotationDrag * gameTime.ElapsedGameTime.TotalSeconds);

                if(Math.Abs(movementComponent.TurnSpeed) < rotationDrag)
                {
                    movementComponent.TurnSpeed = 0;
                }

                if (movementComponent.TurnSpeed > 0)
                {
                    movementComponent.TurnSpeed -= rotationDrag;
                }
                else if(movementComponent.TurnSpeed < 0)
                {
                    movementComponent.TurnSpeed += rotationDrag;
                }
            }
        }
    }
}
