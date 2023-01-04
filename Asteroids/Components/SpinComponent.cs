using BeeECS.Components;

namespace Asteroids.Components
{
    public sealed class SpinComponent : IComponent
    {
        public float RadiansPerSecond { get; set; }
        public float Rotation { get; set; }
    }
}
