using Asteroids.Components;
using BeeECS.Entities;
using BeeECS.Managers;
using BeeECS.Systems;
using Microsoft.Xna.Framework;
using System;

namespace Asteroids.Systems
{
    public sealed class MovementSystem : ECSystem, IUpdatableSystem
    {
        public MovementSystem()
        {
            Enabled = true;

            Requirements = new SystemRequirements();
            Requirements.AddRequirement<MovementComponent>();
        }

        public override SystemRequirements Requirements { get; set; }

        public void Update(GameTime gameTime)
        {
            foreach (Entity entity in Entities)
            {
                MovementComponent movementComponent = ComponentManager.Instance.GetComponent<MovementComponent>(entity);

                Vector2 direction = new Vector2((float)Math.Cos(entity.Transform.Rotation), (float)Math.Sin(entity.Transform.Rotation));
                direction.Normalize();

                movementComponent.Speed = MathHelper.Clamp(movementComponent.Speed, -movementComponent.MaxSpeed, movementComponent.MaxSpeed);

                entity.Transform.Position += direction * (float)(movementComponent.Speed*gameTime.ElapsedGameTime.TotalSeconds);
                entity.Transform.Rotation += movementComponent.TurnSpeed;
            }
        }
    }
}
