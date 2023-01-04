using Asteroids.Components;
using BeeECS.Entities;
using BeeECS.Managers;
using BeeECS.Systems;
using Microsoft.Xna.Framework;

namespace Asteroids.Systems
{
    public sealed class SpinSystem : ECSystem, IUpdatableSystem
    {

        public SpinSystem()
        {
            Enabled = true;
            
            Requirements = new SystemRequirements();
            Requirements.AddRequirement<SpinComponent>();
        }

        public override SystemRequirements Requirements { get; set; }



        public void Update(GameTime gameTime)
        {
            foreach (Entity entity in Entities)
            {
                SpinComponent rotateComponenent = ComponentManager.Instance.GetComponent<SpinComponent>(entity);

                rotateComponenent.Rotation += rotateComponenent.RadiansPerSecond * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
    }
}

