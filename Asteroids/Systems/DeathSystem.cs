using Asteroids.Components;
using BeeECS.Entities;
using BeeECS.Managers;
using BeeECS.Systems;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Asteroids.Systems
{
    sealed class DeathSystem : ECSystem, IUpdatableSystem 
    {
        public DeathSystem()
        {
            Enabled = true;
            
            Requirements = new SystemRequirements();
            Requirements.AddRequirement<CollisionComponent>();
        }

        public override SystemRequirements Requirements { get; set; }

        public void Update(GameTime gameTime)
        {
            for(int i = Entities.Count -1; i >= 0; i--)
            {
                Entity entity = Entities[i];

                CollisionComponent collisionComponent = entity.GetComponent <CollisionComponent>();

                if (collisionComponent.Collided)
                {
                    EntityManager.Instance.DeleteEntity(entity);
                }
            }
        }
    }
}
