using Asteroids.Components;
using BeeECS.Entities;
using BeeECS.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids.Factories
{
    public static class ProjectileFactory
    {
        public static Texture2D Texture;

        public static void CreateProjectile(Vector2 position, float rotation, int factionID)
        {
            Entity projectile = EntityManager.Instance.CreateEntity();

            MovementComponent movementComponent = new MovementComponent() { Speed = 500, MaxSpeed = 500 };
            SpriteComponent spriteComponent = new SpriteComponent() { Texture = Texture, Origin = new Vector2(Texture.Width / 2, Texture.Height / 2), Layer = 0.5f, Source = null };
            CollisionComponent collisionComponent = new CollisionComponent() { Class = "Player", Radius = Texture.Width/2, Collided = false, SecondsToLive = 1.5 };
            SpinComponent rotateComponent = new SpinComponent() { RadiansPerSecond = MathHelper.ToRadians(360) };
            FactionComponent factionComponent = new FactionComponent() { FactionID = factionID };

            projectile.SetPosition(position)
                        .SetRotation(rotation)
                        .AddComponent(movementComponent)
                        .AddComponent(spriteComponent)
                        .AddComponent(collisionComponent)
                        .AddComponent(rotateComponent)
                        .AddComponent(factionComponent);
        }
    }
}
