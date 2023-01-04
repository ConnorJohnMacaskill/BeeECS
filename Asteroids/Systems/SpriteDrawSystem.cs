using Asteroids.Components;
using BeeECS.Entities;
using BeeECS.Managers;
using BeeECS.Systems;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids.Systems
{
    public sealed class SpriteDrawSystem : ECSystem, IDrawableSystem
    {
        public SpriteDrawSystem()
        {
            Enabled = true;
            
            Requirements = new SystemRequirements();
            Requirements.AddRequirement<SpriteComponent>();
        }

        public override SystemRequirements Requirements { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, samplerState: SamplerState.PointClamp);

            foreach (Entity entity in Entities)
            {
                SpriteComponent spriteComponent = ComponentManager.Instance.GetComponent<SpriteComponent>(entity);
                SpinComponent rotateComponent = ComponentManager.Instance.GetComponent<SpinComponent>(entity);

                float rotation = entity.Transform.Rotation;

                if(rotateComponent != null)
                {
                    rotation = rotateComponent.Rotation;
                }

                spriteBatch.Draw(spriteComponent.Texture, entity.Transform.Position, spriteComponent.Source, spriteComponent.Color, rotation, spriteComponent.Origin, spriteComponent.Scale, SpriteEffects.None, 0);
            }

            spriteBatch.End();
        }
    }
}
