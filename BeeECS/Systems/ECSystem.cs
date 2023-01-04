using BeeECS.Entities;
using BeeECS.Managers;
using System.Collections.Generic;

namespace BeeECS.Systems
{
    public abstract class ECSystem
    {
        public bool Enabled { get; set; }

        public List<Entity> Entities { get; set; }

        public abstract SystemRequirements Requirements { get; set; }

        public virtual void ComponentAdded(Entity entity)
        {
        }

        public ECSystem()
        {
            Entities = new List<Entity>();
            Enabled = true;
        }
    }
}
