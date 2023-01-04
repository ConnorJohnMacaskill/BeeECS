using BeeECS.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeECS.Managers
{
    public class SystemManager
    {
        private Dictionary<string, Systems.ECSystem> systems;
        private static SystemManager instance;

        private SystemManager()
        {
            systems = new Dictionary<string, Systems.ECSystem>();
        }

        public static SystemManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SystemManager();
                }

                return instance;
            }
        }

        internal List<ECSystem> GetSystems()
        {
            return systems.Values.ToList();
        }

        internal List<ECSystem> GetSystems(Type componentType)
        {
            //Return systems where their component collection contains the component parameter.
            return systems.Values.Where(x => x.Requirements != null && x.Requirements.Components.Contains(componentType)).ToList();
        }

        public void RegisterSystem(ECSystem system)
        {
            string systemName = system.GetType().Name;

            //We only want one of each system.
            if (!systems.ContainsKey(systemName))
            {
                systems.Add(systemName, system);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Attempted to register a system ({0}) that has already been registered!", systemName));
            }
        }

        public void SetEnabled<ISystem>(bool enabled)
        {
            string systemName = typeof(ISystem).Name;

            if (systems.ContainsKey(systemName))
            {
                systems[systemName].Enabled = enabled;
            }
        }

        public void ToggleEnabled<ISystem>(bool enabled)
        {
            string systemName = typeof(ISystem).Name;

            if (systems.ContainsKey(systemName))
            {
                systems[systemName].Enabled = !systems[systemName].Enabled;
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Systems.ECSystem system in systems.Values)
            {
                if (system.Enabled)
                {
                    IUpdatableSystem updatableSystem = system as IUpdatableSystem;
                    updatableSystem?.Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Systems.ECSystem system in systems.Values)
            {
                if (system.Enabled)
                {
                    IDrawableSystem drawableSystem = system as IDrawableSystem;
                    drawableSystem?.Draw(spriteBatch);
                }
            }
        }
    }
}
