using BeeECS.Components;
using BeeECS.Entities;
using BeeECS.Managers;
using Logging;
using Logging.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BeeECS.Factories
{
    public class EntityFactory
    {
        private static EntityFactory instance;
        private Dictionary<string, IComponentFactory> componentFactories;

        private const string COMPONENTS_NODE_NAME = "Components";

        private EntityFactory()
        {
            componentFactories = new Dictionary<string, IComponentFactory>();
        }

        public static EntityFactory Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new EntityFactory();
                }

                return instance;
            }
        }

        public Entity GetEntity(XElement entityElement)
        {
            Entity entity = EntityManager.Instance.CreateEntity();


            XElement componentsElement = entityElement.Element(COMPONENTS_NODE_NAME);

            foreach(XElement componentElement in componentsElement.Elements())
            {
                IComponent component = GetComponent(componentElement);
                ComponentManager.Instance.AddComponent(entity, component);
            }

            return entity;
        }

        internal void RegisterComponent<T>(IComponentFactory componentFactory) where T : IComponent
        {
            string componentName = typeof(T).Name.ToUpper();
            componentFactories[componentName] = componentFactory;
        }

        private IComponent GetComponent(XElement componentElement)
        {
            IComponent component = null;

            try
            {
                string componentName = componentElement.Name.LocalName.ToUpper();

                if(componentFactories.ContainsKey(componentName))
                {
                    component = componentFactories[componentName].CreateComponent(componentElement);
                }
                else
                {
                    throw new Exception(string.Format("No factory has been registered for component '{0}'.", componentName));
                }
            }
            catch(Exception ex)
            {
                Logger.Log(LogType.Error, string.Format("Error occured while attempting to get a new component from a factory. {0}", ex.ToString()));
                throw;
            }

            return component;
        }
    }
}
