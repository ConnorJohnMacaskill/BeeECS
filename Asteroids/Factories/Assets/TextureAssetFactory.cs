using Asteroids.Assets;
using Microsoft.Xna.Framework.Graphics;
using ResBee.Assets;
using ResBee.Factories;
using System.IO;

namespace Asteroids.Factories.Assets
{
    class TextureAssetFactory : IAssetFactory
    {
        private GraphicsDevice graphicsDevice;

        public TextureAssetFactory(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
        }

        public Asset CreateAsset(string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            Texture2D texture = Texture2D.FromStream(graphicsDevice, fileStream);

            string name = Path.GetFileName(filePath);
            int start = filePath.IndexOf("Assets\\Textures");
            filePath = filePath.Substring(start, filePath.Length - start);

            //Game/Assets/Textures/Ships/Frigate.png
            //Game/Assets/Textures


            return new TextureAsset(filePath,texture);
        }
    }
}
