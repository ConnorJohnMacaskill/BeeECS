using Asteroids.Components;
using BeeECS.Entities;
using BeeECS.Managers;
using BeeECS.Systems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Systems
{
    class HardpointsSystem : ECSystem, IUpdatableSystem
    {
        public HardpointsSystem()
        {
            Requirements = new SystemRequirements();
            Requirements.AddRequirement<HardpointsComponent>();
        }

        public override SystemRequirements Requirements { get; set; }

        public void Update(GameTime gameTime)
        {
            foreach(Entity entity in Entities)
            {
                HardpointsComponent hardpointsComponent = entity.GetComponent<HardpointsComponent>();
                MovementComponent movementComponent = entity.GetComponent<MovementComponent>();

                for(int i = hardpointsComponent.Hardpoints.Count - 1; i >= 0; i--)
                {
                    Hardpoint hardpoint = hardpointsComponent.Hardpoints[i];
                    Entity hardpointEntity = EntityManager.Instance.GetEntity(hardpoint.EntityID);

                    if (hardpointEntity != null)
                    {
                        Matrix transform = Matrix.CreateRotationZ(entity.Transform.Rotation);
                        Vector2 transformedPosition = Vector2.Transform(hardpoint.Offset, transform);

                        hardpointEntity.Transform.Position = entity.Transform.Position + transformedPosition;
                        hardpointEntity.Transform.DefaultRotation = entity.Transform.Rotation;

                        if (movementComponent != null)
                        {
                            hardpointEntity.Transform.Rotation += movementComponent.TurnSpeed;
                        }
                    }
                    else
                    {
                        //Something killed our entity, remove it from the list of hardpoints.
                        hardpointsComponent.Hardpoints.Remove(hardpoint);
                    }
                }

#warning hack remove this.
               // movementComponent.TurnSpeed = 0;
            }
        }
    }
}
