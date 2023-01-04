using Microsoft.Xna.Framework.Graphics;
using ResBee.Assets;

namespace Asteroids.Assets
{
    public class TextureAsset : Asset
    {
        public TextureAsset(string name, Texture2D texture) : base(name)
        {
            Texture = texture;
        }

        public Texture2D Texture { get; private set; }
    }
}
