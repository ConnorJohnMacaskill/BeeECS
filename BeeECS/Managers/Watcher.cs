using BeeECS.Components;
using BeeECS.Entities;
using BeeECS.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeECS.Managers
{
    internal static class Watcher
    {

        public static void ComponentAdded(Entity entity, Type componentType)
        {
            foreach (ECSystem system in SystemManager.Instance.GetSystems(componentType))
            {
                CheckSystem(entity, system);
            }
        }

        public static void ComponentRemoved(Entity entity, Type componentType)
        {
            foreach (ECSystem system in SystemManager.Instance.GetSystems(componentType))
            {
                system.Entities.Remove(entity);
            }
        }

        public static void EntityRemoved(Entity entity)
        {
            SystemManager.Instance.GetSystems().ForEach(x => x.Entities.Remove(entity));
        }

        private static void CheckSystem(Entity entity, ECSystem system)
        {
            if (!system.Entities.Contains(entity))
            {
                //If the entity doesn't have a required component don't add it and return the method.
                foreach (Type componentType in system.Requirements?.Components)
                {
                    if (!ComponentManager.Instance.HasComponent(entity, componentType))
                    {
                        return;
                    }
                }

                system.Entities.Add(entity);
                system.ComponentAdded(entity);
            }
        }
    }
}
