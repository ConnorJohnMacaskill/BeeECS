using Asteroids.Assets;
using Asteroids.Components;
using BeeECS.Components;
using BeeECS.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ResBee.Stores;
using System.Xml.Linq;

namespace Asteroids.Factories.Components
{
    public class SpriteComponentFactory : IComponentFactory
    {
        public IComponent CreateComponent(XElement componentData)
        {
            string rawPath = componentData.Element("Path").Value;
            string rawOrigin = componentData.Element("Origin").Value;
            string rawScale = componentData.Element("Scale").Value;
            string rawColor = componentData.Element("Color")?.Value;

            Texture2D texture = ValueFactory.GetTexture(rawPath, true);
            Vector2 origin = ValueFactory.GetVector2(rawOrigin, true);
            float scale = ValueFactory.GetFloat(rawScale, false);
            Color color = ValueFactory.GetColor(rawColor, false);

            SpriteComponent rotateComponent = new SpriteComponent()
            {
                Texture = texture,
                Origin = origin,
                Scale = scale,
                Color = color
            };

            return rotateComponent;
        }
    }
}
