using Asteroids.Components;
using Asteroids.Events;
using BeeECS.Entities;
using BeeECS.Events;
using BeeECS.Managers;
using BeeECS.Systems;
using Microsoft.Xna.Framework;

namespace Asteroids.Systems
{
    sealed class PlayerSystem : ECSystem, IUpdatableSystem
    {
        public PlayerSystem()
        {
            Enabled = true;

            Requirements = new SystemRequirements();
            Requirements.AddRequirement<MovementComponent>();
            Requirements.AddRequirement<ProjectileWeaponComponent>();
            Requirements.AddRequirement<PlayerComponent>();

            EventManager.Instance.RegisterAction(InputEvent.MoveForwards, MoveForwards);
            EventManager.Instance.RegisterAction(InputEvent.MoveBackwards, MoveBackwards);
            EventManager.Instance.RegisterAction(InputEvent.TurnLeft, TurnLeft);
            EventManager.Instance.RegisterAction(InputEvent.TurnRight, TurnRight);
            EventManager.Instance.RegisterAction(InputEvent.Shoot, Shoot);
        }

        public override SystemRequirements Requirements { get; set; }

        private void MoveForwards(GameTime gameTime, GameEvent gameEvent)
        {
            foreach (Entity entity in Entities)
            {
                MovementComponent movementComponent = ComponentManager.Instance.GetComponent<MovementComponent>(entity);
                //velocity.Velocity *= velocity.AccelerationPerSecond * gameTime.ElapsedGameTime.TotalSeconds;
                movementComponent.Speed += (float)(movementComponent.AccelerationPerSecond * gameTime.ElapsedGameTime.TotalSeconds);

            }
        }

        private void MoveBackwards(GameTime gameTime, GameEvent gameEvent)
        {
            foreach (Entity entity in Entities)
            {
                MovementComponent movementComponent = ComponentManager.Instance.GetComponent<MovementComponent>(entity);
                //velocity.Velocity *= velocity.AccelerationPerSecond * gameTime.ElapsedGameTime.TotalSeconds;
                movementComponent.Speed -= (float)(movementComponent.AccelerationPerSecond * gameTime.ElapsedGameTime.TotalSeconds);
            }

        }

        private void TurnLeft(GameTime gameTime, GameEvent gameEvent)
        {
            foreach (Entity entity in Entities)
            {
                MovementComponent movementComponent = ComponentManager.Instance.GetComponent<MovementComponent>(entity);
                movementComponent.TurnSpeed = -(float)(movementComponent.RadiansPerSecond * gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        private void TurnRight(GameTime gameTime, GameEvent gameEvent)
        {
            foreach (Entity entity in Entities)
            {
                MovementComponent movementComponent = ComponentManager.Instance.GetComponent<MovementComponent>(entity);
                movementComponent.TurnSpeed = (float)(movementComponent.RadiansPerSecond * gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        private void Shoot(GameTime gameTime, GameEvent gameEvent)
        {
            foreach (Entity entity in Entities)
            {
                ProjectileWeaponComponent weaponComponent = ComponentManager.Instance.GetComponent<ProjectileWeaponComponent>(entity);

                WeaponEventData weaponEventData = new WeaponEventData() { Entity = entity, LastShot = false };
                gameEvent = new GameEvent(RangedWeaponAction.Fire, weaponEventData);

                EventManager.Instance.QueueEvent(gameEvent);
            }
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
