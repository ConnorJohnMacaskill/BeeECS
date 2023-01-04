using Asteroids.Components;
using BeeECS.Entities;
using BeeECS.Managers;
using BeeECS.Systems;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids.Systems
{
    sealed class CollisionSystem : ECSystem, IUpdatableSystem
    {
        public CollisionSystem()
        {
            Enabled = true;
            
            Requirements = new SystemRequirements();
            Requirements.AddRequirement<CollisionComponent>();
        }

        public override SystemRequirements Requirements { get; set; }

        public void Update(GameTime gameTime)
        {
            //For each player collision
            //Check if it hits a asteroid collision

            /*
             * for (i=0; i++, i < length(entity_list):
            for (j=i, j++, j < length(entity_list):
            check_collision(entity_list[i], entity_list[j])
            

            for(int i = 0; i < Entities.Count; i++)
            {
                Entity entityOne = Entities[i];
                CollisionComponent collisionComponentOne = entityOne.GetComponent<CollisionComponent>();

                for (int j = i; j < Entities.Count; j++)
                {
                    Entity entityTwo = Entities[j];
                    CollisionComponent collisionComponentTwo = entityTwo.GetComponent<CollisionComponent>();

                    float distance = collisionComponentOne.Radius + collisionComponentTwo.Radius;

                    if (Vector2.Distance(entityOne.Transform.Position, entityTwo.Transform.Position) <= distance)
                    {
                        collisionComponentOne.Collided = true;
                        collisionComponentTwo.Collided = true;
                    }
                }
            }*/

            
            foreach (Entity entityOne in Entities.Where(x => x.GetComponent<CollisionComponent>().Class == "Player"))
            {
                CollisionComponent collisionComponentOne = ComponentManager.Instance.GetComponent<CollisionComponent>(entityOne);

                if(collisionComponentOne.SecondsToLive != -1)
                {
                    collisionComponentOne.SecondsToLive -= gameTime.ElapsedGameTime.TotalSeconds;

                    if(collisionComponentOne.SecondsToLive <= 0)
                    {
                        collisionComponentOne.Collided = true;
                    }
                }

                

                if (!collisionComponentOne.Collided)
                {
                    //if (collisionComponent.Class == Class.Ship)
                    //{
                    foreach (Entity entityTwo in Entities.Where(x => x.GetComponent<CollisionComponent>().Class == "Asteroid"))
                    {
                        CollisionComponent collisionComponentTwo = entityTwo.GetComponent<CollisionComponent>();

                        float distance = collisionComponentOne.Radius + collisionComponentTwo.Radius;

                        if (Vector2.Distance(entityOne.Transform.Position, entityTwo.Transform.Position) <= distance)
                        {
                            collisionComponentOne.Collided = true;
                            collisionComponentTwo.Collided = true;
                        }
                    }
                    //}
                }
            }
        }
    }
}
