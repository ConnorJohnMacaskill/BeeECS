using Asteroids.Components;
using BeeECS.Entities;
using BeeECS.Managers;
using BeeECS.Systems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Systems
{
    class TargetSystem : ECSystem, IUpdatableSystem
    {
        public TargetSystem()
        {
            Requirements = new SystemRequirements();
            Requirements.AddRequirement<TargetComponent>();
        }

        public override SystemRequirements Requirements { get; set; }

        public void Update(GameTime gameTime)
        {
            foreach (Entity entity in Entities)
            {
                TargetComponent targetComponent = entity.GetComponent<TargetComponent>();
                FactionComponent factionComponent = entity.GetComponent<FactionComponent>();

                foreach (Entity potentionalTarget in EntityManager.Instance.GetEntities<SpinComponent>())
                {
                    FactionComponent targetFactionComponent = potentionalTarget.GetComponent<FactionComponent>();

                    if(factionComponent.FactionID == targetFactionComponent.FactionID)
                    {
                        continue;
                    }

                    if(Vector2.Distance(entity.Transform.Position, potentionalTarget.Transform.Position) < targetComponent.Range)
                    {
                        targetComponent.TargetID = potentionalTarget.ID;
                        break;
                    }
                }
            }
        }
    }
}
