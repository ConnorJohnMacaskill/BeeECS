using BeeECS.Components;
using BeeECS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BeeECS.Managers
{
    public class EntityManager
    {

        private Dictionary<int, Entity> entities;
        private static EntityManager instance;
        private int idCounter;
       

        private EntityManager()
        {
            entities = new Dictionary<int, Entity>();
            idCounter = 0;
        }

        public static EntityManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new EntityManager();
                }

                return instance;
            }
        }

        private int GetNextID()
        {
            return idCounter++;
        }

        public Entity CreateEntity()
        {
            int nextID = GetNextID();

            Entity entity = new Entity()
            {
                ID = nextID
            };

            entities.Add(nextID, entity);

            return entity;
        }

        public void Update()
        {
            //Instead of looping through every entity for each system.
            //Loop through every entity here.
            //Have a dictionary of systems for each entity.
            //Call UpdateEntity(entity) on each system?

            //Dictionary<Entity List<Systems>()
            //on adding component
            //do logic to find systems
            //instead of adding to system entity, add to dictionary
            //More memory usage?, but faster?.

        }

        public List<Entity> GetEntities<T>() where T : class, IComponent
        {
            return entities.Values.Where(x => x.HasComponent<T>()).ToList();
        }

        /// <summary>
        /// Get an Entity by ID.
        /// </summary>
        /// <param name="id">The ID of the entity to get.</param>
        /// <returns>The entity or null if it doesn't exist. </returns>
        public Entity GetEntity(int id)
        {
            Entity retVal = null;

            if(entities.ContainsKey(id))
            {
                retVal = entities[id];
            }
           
            return retVal;
        }

        public void DeleteEntity(Entity entity)
        {
            if (entities.Keys.Contains(entity.ID))
            {
                ComponentManager.Instance.RemoveAllComponents(entity);
                entities.Remove(entity.ID);
                Watcher.EntityRemoved(entity);
            }
        }

        public int Count()
        {
            return entities.Count;
        }
    }
}
