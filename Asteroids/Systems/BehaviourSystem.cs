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
    class BehaviourSystem : ECSystem, IUpdatableSystem
    {
        public BehaviourSystem()
        {
            Enabled = true;
            Requirements = new SystemRequirements();
            Requirements.AddRequirement<BehaviourComponent>();
        }

        public override SystemRequirements Requirements { get; set; }

        public void Update(GameTime gameTime)
        {
            foreach (Entity entity in Entities)
            {
                BehaviourComponent behaviourComponent = ComponentManager.Instance.GetComponent<BehaviourComponent>(entity);
                behaviourComponent.Tree.Update(entity);
            }
        }
    }
}