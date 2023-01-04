using BeeECS.Components;

namespace Asteroids.Components
{
    public sealed class DragComponent : IComponent
    {
        public float MovementDrag { get; set; }
        public float RotationDrag { get; set; }
    }
}
