using Microsoft.Xna.Framework;

namespace BeeECS.Entities
{
    public sealed class Transform
    {
        public Transform()
        {
            Position = new Vector2();
            Rotation = 0.0f;
        }

        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public float DefaultRotation { get; set; }
    }
}
