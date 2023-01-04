using BeeECS.Components;
using BeeECS.Managers;
using Microsoft.Xna.Framework;

namespace BeeECS.Entities
{
    public sealed class Entity
    {
        internal Entity()
        {
            Transform = new Transform();
        }

        public int ID { get; set; }

        public Transform Transform { get; set; }

        public Entity SetPosition(Vector2 position)
        {
            Transform.Position = position;
            return this;
        }

        public Entity SetRotation(float rotation)
        {
            Transform.Rotation = rotation;
            return this;
        }

        public Entity AddComponent(IComponent component)
        {
            ComponentManager.Instance.AddComponent(this, component);
            return this;
        }

        public bool HasComponent<T>() where T : class, IComponent
        {
            return ComponentManager.Instance.HasComponent<T>(this);
        }

        public T GetComponent<T>() where T : class, IComponent
        {
            return ComponentManager.Instance.GetComponent<T>(this);
        }

        public void RemoveComponent<T>() where T : class, IComponent
        {
            ComponentManager.Instance.RemoveComponent<T>(this);
        }
    }
}
