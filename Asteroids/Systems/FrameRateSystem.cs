using BeeECS.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Systems
{
    public class FrameRateSystem : ECSystem, IUpdatableSystem, IDrawableSystem
    {
        SpriteFont spriteFont;
        int totalFrames;
        int framesPerSecond;
        double elapsedTime;

        public FrameRateSystem(SpriteFont spriteFont)
        {
            this.spriteFont = spriteFont;
            totalFrames = 0;
            framesPerSecond = 0;
            elapsedTime = 0f;

            Enabled = true;
            Requirements = new SystemRequirements();
        }

        public override SystemRequirements Requirements { get; set; }

        public void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;

            if(elapsedTime >= 1000)
            {
                framesPerSecond = totalFrames;
                totalFrames = 0;
                elapsedTime = 0;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            string fpsText = string.Format("FPS = {0}", framesPerSecond);

            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, fpsText, new Vector2(9, 9), Color.Black);
            spriteBatch.DrawString(spriteFont, fpsText, new Vector2(11, 9), Color.Black);
            spriteBatch.DrawString(spriteFont, fpsText, new Vector2(9, 11), Color.Black);
            spriteBatch.DrawString(spriteFont, fpsText, new Vector2(11, 11), Color.Black);
            spriteBatch.DrawString(spriteFont, fpsText, new Vector2(10, 10), Color.White);
            spriteBatch.End();

            totalFrames++;
        }
    }
}
