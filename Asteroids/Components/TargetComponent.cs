using BeeECS.Components;
using BeeECS.Entities;
using BeeECS.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Components
{
    class TargetComponent : IComponent
    {
        public int TargetID { get; set; }
        public int Range { get; set; }

        public Entity Target
        {
            get
            {
                return EntityManager.Instance.GetEntity(TargetID);
            }
        }
    }
}
