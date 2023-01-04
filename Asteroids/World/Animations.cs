using Asteroids.Models;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Asteroids.World
{
    public class Animations
    {
        private int currentFrameIndex;
        private Dictionary<string, Animation> animations;

        public Animations(Dictionary<string, Animation> animations)
        {
            this.currentFrameIndex = 0;
            this.animations = animations;
        }

        public Animation CurrentAnimation { get; private set; }

        public Frame CurrentFrame
        {
            get
            {
                return CurrentAnimation.Frames[currentFrameIndex];
            }
        }

        public void PlayAnimation(string animationName)
        {
            if (!animations.ContainsKey(animationName))
            {
                //Play the idle animation and log the missing animation.
                //Logging
            }            // TODO: Finish animation.
        }

        public void Update(GameTime gameTime)
        {
            //Frame currentFrame = CurrentAnimation.

            /*currentFrame.ElapsedDuration += gameTime.ElapsedGameTime.Milliseconds;

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
    }
}
