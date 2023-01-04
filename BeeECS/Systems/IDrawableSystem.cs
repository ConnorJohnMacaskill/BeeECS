using Microsoft.Xna.Framework.Graphics;

namespace BeeECS.Systems
{
    public interface IDrawableSystem
    {
        void Draw(SpriteBatch spriteBatch);
    }
}
