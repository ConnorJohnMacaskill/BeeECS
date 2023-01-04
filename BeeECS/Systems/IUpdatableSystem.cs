using Microsoft.Xna.Framework;

namespace BeeECS.Systems
{
    public interface IUpdatableSystem
    {
        void Update(GameTime gameTime);
    }
}
