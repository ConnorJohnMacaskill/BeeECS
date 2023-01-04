using BeeECS.Components;
using BeeECS.Entities;
using BeeECS.Factories;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BeeECS.Managers
{
    public class ComponentManager
    {
        private static ComponentManager instance;
        private Dictionary<Type, ComponentContainer> components;

        private ComponentManager()
        {
            components = new Dictionary<Type, ComponentContainer>();
        }

        public void RegisterComponent<T>(IComponentFactory componentFactory) where T : IComponent
        {
            Type componentType = typeof(T);

            if (!components.ContainsKey(componentType))
            {
                components.Add(componentType, new ComponentContainer());
                EntityFactory.Instance.RegisterComponent<T>(componentFactory);
            }
            else
            {
                throw new Exception(string.Format("A component with the name '{0}' has already been registered.", componentType.Name));
            }
        }

        public void AddComponent(Entity entity, IComponent component)
        {
            Type componentType = component.GetType();

            components[componentType][entity.ID] = component;
            Watcher.ComponentAdded(entity, componentType);
        }

        public void RemoveComponent<T>(Entity entity) where T : IComponent
        {
            Type componentType = typeof(T);
            RemoveComponent(entity, componentType);
        }

        public void RemoveComponent(Entity entity, IComponent component)
        {
            Type componentType = component.GetType();
            RemoveComponent(entity, componentType);
        }

        private void RemoveComponent(Entity entity, Type componentType)
        {
            components[componentType].RemoveComponent(entity.ID);
            Watcher.ComponentRemoved(entity, componentType);
        }

        public bool HasComponent<T>(Entity entity) where T : IComponent
        {
            Type componentType = typeof(T);
            return HasComponent(entity, componentType);
        }

        public bool HasComponent(Entity entity, IComponent component)
        {
            Type componentType = component.GetType();
            return HasComponent(entity, componentType);
        }

        internal bool HasComponent(Entity entity, Type componentType)
        {
            return components[componentType].HasKey(entity.ID);
        }
        

        public void RemoveAllComponents(Entity entity)
        {
            foreach (Type componentType in components.Keys)
            {
                RemoveComponent(entity, componentType);
            }
        }

        public T GetComponent<T>(Entity entity) where T : class, IComponent
        {
            Type componentType = typeof(T);
            T retVal = default(T);

            if (components.ContainsKey(componentType))
            {
                retVal = components[componentType][entity.ID] as T;
            }

            return retVal;
        }

        public static ComponentManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ComponentManager();
                }

                return instance;
            }
        }
    }
}
