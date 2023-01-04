using Asteroids.Components;
using Asteroids.Factories.Components;
using BeeECS.Entities;
using BeeECS.Managers;
using BeeECS.Systems;
using Microsoft.Xna.Framework;

namespace Asteroids.Systems
{
    sealed class BoundsSystem : ECSystem, IUpdatableSystem
    {
        public BoundsSystem()
        {
            Enabled = true;
            //throw new Exception();
            //add entityadded method for custom compontent setup when entity is added to the system.
            //entity removed method also?
            //Or make them subscribale events, although sirect method call will suffice for now.
            //I guess I could make it up to myself, the user.
            //call method ComponentAdded, called when component added and passes entity to the method.
            //Example - Asteroid movement system could set a random velocity.
            
            Requirements = new SystemRequirements();
            Requirements.AddRequirement<BoundsComponent>();
            Requirements.AddRequirement<MovementComponent>();
        }

        public override SystemRequirements Requirements { get; set; }

        public void Update(GameTime gameTime)
        {
            foreach(Entity entity in Entities)
            {
                MovementComponent movementComponent = ComponentManager.Instance.GetComponent<MovementComponent>(entity);

                if(entity.Transform.Position.X < -40)
                {
                    entity.Transform.Position += new Vector2(838,0);
                }
                else if(entity.Transform.Position.X > 840)
                {
                    entity.Transform.Position -= new Vector2(838, 0);
                }

                if (entity.Transform.Position.Y < -40)
                {
                    entity.Transform.Position += new Vector2(0, 838);
                }
                else if (entity.Transform.Position.Y > 840)
                {
                    entity.Transform.Position -= new Vector2(0, 838);
                }
            }
        }
    }
}
