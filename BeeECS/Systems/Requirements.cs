using BeeECS.Components;
using System;
using System.Collections.Generic;

namespace BeeECS.Systems
{
    public class SystemRequirements
    {
        public SystemRequirements()
        {
            Components = new List<Type>();
        }
        
        internal List<Type> Components { get; private set; }

        /// <summary>
        /// Adds the component type to this SystmRequirements object, ignores duplicates.
        /// </summary>
        /// <typeparam name="T">The type of component to add.</typeparam>
        public void AddRequirement<T>() where T : IComponent
        {
            Type type = typeof(T);

            if (!Components.Contains(type))
            {
                Components.Add(type);
            }
        }
    }
}
