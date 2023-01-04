using Asteroids.Components;
using Asteroids.Systems;
using BeeECS.Entities;
using BeeECS.Events;
using BeehaviorTree.Enums;
using BeehaviorTree.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Behaviour
{
    class ActionShootNode : INode
    {
        public void Reset()
        {
        }

        public State Update(Entity entity)
        {
            ProjectileWeaponComponent weaponComponent = entity.GetComponent<ProjectileWeaponComponent>();
            
            if(weaponComponent != null)
            {
                WeaponEventData weaponEventData = new WeaponEventData() { Entity = entity, LastShot = false };
                GameEvent gameEvent = new GameEvent(RangedWeaponAction.Fire, weaponEventData);

                EventManager.Instance.QueueEvent(gameEvent);

                return State.Success;
            }

            return State.Failure;
        }
    }
}
