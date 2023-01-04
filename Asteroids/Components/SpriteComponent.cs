using BeeECS.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids.Components
{
    public sealed class SpriteComponent : IComponent
    {
        public SpriteComponent()
        {
            Texture = null;
            Origin = new Vector2(0, 0);
            Scale = 1.0f;
            Color = Color.White;
            Layer = 1.0f;
            Source = null;
        }

        public Texture2D Texture { get; set; }
        public Vector2 Origin { get; set; }
        public float Scale { get; set; }
        public Color Color { get; set; }
        public float Layer { get; set; }
        public Rectangle? Source { get; set; }
    }
}