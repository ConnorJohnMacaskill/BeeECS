using Asteroids.World;
using BeeECS.Components;

namespace Asteroids.Components
{
    public sealed class AnimationComponent : IComponent
    {
        public AnimationComponent()
        {
        }

        public AnimationComponent(Animations animations)
        {
            Animations = animations;
        }

        public Animations Animations { get; set; }
    }
}
