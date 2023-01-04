using BeeECS.Components;
using System.Collections.Generic;
using System.Linq;

namespace BeeECS.Managers
{
    public class ComponentContainer
    {
        private Dictionary<int, IComponent> components;

        public ComponentContainer()
        {
            components = new Dictionary<int, IComponent>();
        }

        public IComponent this[int id]
        {
            get
            {
                return GetComponent(id);
            }
            set
            {
                SetComponent(id, value);
            }
        }

        public List<IComponent> Components
        {
            get
            {
                return components.Values.Where(x => x != null).ToList();
            }
        }

        public IComponent GetComponent(int id)
        {
            if (components.ContainsKey(id))
            {
                return components[id];
            }

            return null;
        }

        public void SetComponent(int id, IComponent component)
        {
            if (components.ContainsKey(id))
            {
                components[id] = component;
            }
            else
            {
                components.Add(id, component);
            }
        }

        public void RemoveComponent(int id)
        {
            if (components.ContainsKey(id))
            {
                components.Remove(id);
            }
        }

        public bool HasKey(int id)
        {
            return components.ContainsKey(id);
        }
    }
}
