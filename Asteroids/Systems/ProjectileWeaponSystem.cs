using Asteroids.Components;
using Asteroids.Factories;
using BeeECS.Entities;
using BeeECS.Events;
using BeeECS.Systems;
using Microsoft.Xna.Framework;

namespace Asteroids.Systems
{
    sealed class ProjectileWeaponSystem : ECSystem, IUpdatableSystem
    {
        public ProjectileWeaponSystem()
        {
            Enabled = true;
            
            Requirements = new SystemRequirements();
            Requirements.AddRequirement<ProjectileWeaponComponent>();

            EventManager.Instance.RegisterAction(RangedWeaponAction.Fire, FireWeapon);
            EventManager.Instance.RegisterAction(RangedWeaponAction.FireExtra, FireWeaponExtra);
        }

        private void FireWeapon(GameTime gameTime, GameEvent gameEvent)
        {
            WeaponEventData weaponEventData = gameEvent.Data as WeaponEventData;

            ProjectileWeaponComponent weaponComponent = weaponEventData.Entity.GetComponent<ProjectileWeaponComponent>();
            FactionComponent factionComponent = weaponEventData.Entity.GetComponent<FactionComponent>();

            if (weaponComponent.Timer == 0 && !weaponComponent.Firing)
            {
                ProjectileFactory.CreateProjectile(weaponEventData.Entity.Transform.Position, weaponEventData.Entity.Transform.Rotation, factionComponent.FactionID);

                weaponComponent.Timer = weaponComponent.SecondsPerShot;
               /* weaponComponent.Firing = true;

                gameEvent = new GameEvent(RangedWeaponAction.FireExtra, weaponEventData);
                EventManager.Instance.QueueEvent(gameEvent, 0.01);

                gameEvent = new GameEvent(RangedWeaponAction.FireExtra, weaponEventData);
                EventManager.Instance.QueueEvent(gameEvent, 0.02);

                gameEvent = new GameEvent(RangedWeaponAction.FireExtra, weaponEventData);
                EventManager.Instance.QueueEvent(gameEvent, 0.03);

                weaponEventData.LastShot = true;
                gameEvent = new GameEvent(RangedWeaponAction.FireExtra, weaponEventData);
                EventManager.Instance.QueueEvent(gameEvent, 0.04);*/
            }
        }

        private void FireWeaponExtra(GameTime gameTime, GameEvent gameEvent)
        {
            WeaponEventData weaponEventData = gameEvent.Data as WeaponEventData;

            ProjectileWeaponComponent weaponComponent = weaponEventData.Entity.GetComponent<ProjectileWeaponComponent>();
            FactionComponent factionComponent = weaponEventData.Entity.GetComponent<FactionComponent>();

            ProjectileFactory.CreateProjectile(weaponEventData.Entity.Transform.Position, weaponEventData.Entity.Transform.Rotation, factionComponent.FactionID);

            if(weaponEventData.LastShot)
            {
                weaponComponent.Firing = false;
            }
        }

        public override SystemRequirements Requirements { get; set; }

        public void Update(GameTime gameTime)
        {
            foreach(Entity entity in Entities)
            {
                ProjectileWeaponComponent weaponComponent = entity.GetComponent<ProjectileWeaponComponent>();
              
                if(weaponComponent.Timer > 0 && !weaponComponent.Firing)
                {
                    weaponComponent.Timer -= gameTime.ElapsedGameTime.TotalSeconds;

                    if(weaponComponent.Timer < 0)
                    {
                        weaponComponent.Timer = 0;
                    }
                }
            }
        }
    }

    public class WeaponEventData
    {
        public Entity Entity { get; set; }
        public bool LastShot { get; set; }
    }

    public enum RangedWeaponAction
    {
        Fire,
        FireExtra
    }
}
