using Asteroids.Components;
using Asteroids.Factories;
using ECS.Base.Entities;
using ECS.Base.Managers;
using ECS.Base.Systems;
using Microsoft.Xna.Framework;

namespace Asteroids.Systems
{
    sealed class WeaponSystem : ECSystem, IUpdatableSystem
    {
        public WeaponSystem()
        {
            Enabled = true;
            Components = new ComponentCollection();
            Components.Add("WeaponComponent");
        }

        public override ComponentCollection Components { get; set; }

        public void Update(GameTime gameTime)
        {
            foreach(Entity entity in Entities)
            {
                WeaponComponent weaponComponent = entity.GetComponent<WeaponComponent>();
              

                if(weaponComponent.Timer > 0)
                {
                    weaponComponent.Timer -= gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    if(weaponComponent.Fire)
                    {
                        ProjectileFactory.CreateProjectile(entity.Transform.Position, entity.Transform.Rotation);
                        weaponComponent.Timer = weaponComponent.SecondsPerShot;
                    }
                }

                weaponComponent.Fire = false;
            }
        }
    }
}
