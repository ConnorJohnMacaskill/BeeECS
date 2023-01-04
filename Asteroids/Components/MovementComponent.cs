using BeeECS.Components;
using Microsoft.Xna.Framework;

namespace Asteroids.Components
{
    public sealed class MovementComponent : IComponent
    {
        public float AccelerationPerSecond { get; set; }
        public float Speed { get; set; }
        public float MaxSpeed { get; set; }
        public float RadiansPerSecond { get; set; }
        public float TurnSpeed { get; set; }
    }
}
