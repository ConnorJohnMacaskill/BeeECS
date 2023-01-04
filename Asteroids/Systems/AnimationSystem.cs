using Asteroids.Components;
using Asteroids.Enums;
using BeeECS.Entities;
using BeeECS.Events;
using BeeECS.Systems;
using Microsoft.Xna.Framework;

namespace Asteroids.Systems
{
    public sealed class AnimationSystem : ECSystem, IUpdatableSystem
    {
        public AnimationSystem()
        {
            Requirements = new SystemRequirements();
            Requirements.AddRequirement<SpriteComponent>();
            Requirements.AddRequirement<AnimationComponent>();

            EventManager.Instance.RegisterAction(AnimationEvents.PLAY, PlayAnimation);

            Enabled = true;
        }

        public override SystemRequirements Requirements { get; set; }

        public void Update(GameTime gameTime)
        {
            Entities.ForEach(x => RunAnimation(x, gameTime));
        }

        private void PlayAnimation(GameTime gameTime, GameEvent gameEvent)
        {
            AnimationEventData animationEventData = gameEvent.Data as AnimationEventData;

            AnimationComponent animationComponent = animationEventData.Entity.GetComponent<AnimationComponent>();
            /*
            if (animationComponent != null)
            {
                animationComponent.CurrentAnimation = animationComponent.Animations[animationEventData.AnimationName];
                animationComponent.CurrentFrame = 0;
                animationComponent.PlayOnce = animationEventData.PlayOnce;
            }*/
        }

        private void RunAnimation(Entity entity, GameTime gameTime)
        {
            AnimationComponent animationComponent = entity.GetComponent<AnimationComponent>();
            SpriteComponent spriteComponent = entity.GetComponent<SpriteComponent>();
            /*
            Frame currentFrame = animationComponent.CurrentAnimation.Frames[animationComponent.CurrentFrame];

            currentFrame.ElapsedDuration += gameTime.ElapsedGameTime.Milliseconds;

            if (currentFrame.Duration <= currentFrame.ElapsedDuration)
            {
                //Move on to next frame.
                animationComponent.CurrentFrame += 1;

                if (animationComponent.CurrentFrame >= animationComponent.CurrentAnimation.Frames.Length)
                {
                    //Reset animation.
                    if (animationComponent.PlayOnce)
                    {
                        animationComponent.CurrentAnimation = animationComponent.Animations["Idle"];
                        animationComponent.PlayOnce = false;
                    }

                    animationComponent.CurrentFrame = 0;
                }

                currentFrame = animationComponent.CurrentAnimation.Frames[animationComponent.CurrentFrame];
                currentFrame.ElapsedDuration = 0;

                spriteComponent.Source = currentFrame.Dimensions;
            }
        }*/
        }

        public class AnimationEventData
        {
            public Entity Entity { get; set; }
            public string AnimationName { get; set; }
            public bool PlayOnce { get; set; }
        }
    }
}