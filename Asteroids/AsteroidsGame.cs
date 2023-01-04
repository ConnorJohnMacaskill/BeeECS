using Asteroids.Assets;
using Asteroids.Behaviour;
using Asteroids.Components;
using Asteroids.Factories;
using Asteroids.Factories.Assets;
using Asteroids.Factories.Components;
using Asteroids.Systems;
using Asteroids.Utility;
using BeeECS.Components;
using BeeECS.Entities;
using BeeECS.Events;
using BeeECS.Factories;
using BeeECS.Managers;
using BeehaviorTree;
using BeehaviorTree.Nodes;
using BeehaviorTree.Nodes.Composite;
using Logging;
using Logging.LogWriters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ResBee.Assets;
using ResBee.Loaders;
using ResBee.Stores;
using System;
using System.Collections.Generic;
using System.IO;

namespace Asteroids
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class AsteroidsGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Random random;


        public AsteroidsGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 800;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            random = new Random();

            FileLogWriter fileLogWriter = new FileLogWriter(@"Log.txt");
            DebugLogWriter debugLogWriter = new DebugLogWriter();
            Logger.Initialise("Asteroids", fileLogWriter, debugLogWriter);

            base.Initialize();
        }

        private void LoadAssets()
        {
            string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "Assets");

            List<AssetDefinition> assetDefinitions = new List<AssetDefinition>();
            assetDefinitions.Add(AssetDefinition.Create<TextureAsset>(Path.Combine(rootPath, "Textures"), new TextureAssetFactory(GraphicsDevice), true));
            assetDefinitions.Add(AssetDefinition.Create<EntityAsset>(Path.Combine(rootPath, "Entities"), new EntityAssetFactory(), true));

            ResourceLoader.LoadResources(assetDefinitions);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            LoadAssets();

            SpriteFont framesFont = Content.Load<SpriteFont>("Frames");

            ProjectileFactory.Texture = Content.Load<Texture2D>("SmallBullet");


            SystemManager.Instance.RegisterSystem(new BehaviourSystem());
            SystemManager.Instance.RegisterSystem(new InputSystem());
            SystemManager.Instance.RegisterSystem(new AnimationSystem());
            SystemManager.Instance.RegisterSystem(new MovementSystem());
            SystemManager.Instance.RegisterSystem(new PlayerSystem());
            SystemManager.Instance.RegisterSystem(new BoundsSystem());
            SystemManager.Instance.RegisterSystem(new SpinSystem());
            SystemManager.Instance.RegisterSystem(new CollisionSystem());
            SystemManager.Instance.RegisterSystem(new DeathSystem());
            SystemManager.Instance.RegisterSystem(new ProjectileWeaponSystem());
            SystemManager.Instance.RegisterSystem(new TargetSystem());
            SystemManager.Instance.RegisterSystem(new HardpointsSystem());
            SystemManager.Instance.RegisterSystem(new SpriteDrawSystem());
            SystemManager.Instance.RegisterSystem(new DragSystem());
            SystemManager.Instance.RegisterSystem(new FrameRateSystem(framesFont));

            ComponentManager.Instance.RegisterComponent<BehaviourComponent>(new BehaviourComponentFactory());
            ComponentManager.Instance.RegisterComponent<AnimationComponent>(null);
            ComponentManager.Instance.RegisterComponent<SpriteComponent>(new SpriteComponentFactory());
            ComponentManager.Instance.RegisterComponent<MovementComponent>(new MovementComponentFactory());
            ComponentManager.Instance.RegisterComponent<PlayerComponent>(new PlayerComponentFactory());
            ComponentManager.Instance.RegisterComponent<SpinComponent>(new SpinComponentFactory());
            ComponentManager.Instance.RegisterComponent<CollisionComponent>(new CollisionComponentFactory());
            ComponentManager.Instance.RegisterComponent<ProjectileWeaponComponent>(new ProjectileWeaponComponentFactory());
            ComponentManager.Instance.RegisterComponent<TargetComponent>(new TargetComponentFactory());
            ComponentManager.Instance.RegisterComponent<HardpointsComponent>(new HardpointsComponentFactory());
            ComponentManager.Instance.RegisterComponent<FactionComponent>(new FactionComponentFactory());
            ComponentManager.Instance.RegisterComponent<BoundsComponent>(new BoundsComponentFactory());
            ComponentManager.Instance.RegisterComponent<DragComponent>(new DragComponentFactory());

            EntityAsset shipAsset = AssetStore.Instance.GetAsset<EntityAsset>("Player");
            Entity shipEntity = EntityFactory.Instance.GetEntity(shipAsset.EntityData);
            SetFaction(shipEntity, 1);
            shipEntity.Transform.Position = new Vector2(100, 100);

            RotateTowardsTargetNode node = new RotateTowardsTargetNode();
            CheckFacingTargetNode targetNode = new CheckFacingTargetNode(0.3f);
            ActionShootNode shootNode = new ActionShootNode();
            SequenceNode sequenceNode = new SequenceNode(new INode[] { node, targetNode, shootNode }, false);

            for (int i = 0; i < 40; i++)
            {

                EntityAsset entityAsset = AssetStore.Instance.GetAsset<EntityAsset>("Asteroid");
                Entity asteroid = EntityFactory.Instance.GetEntity(entityAsset.EntityData);
                SetFaction(asteroid, 2);
                asteroid.Transform.Position = RandomPosition();

                if (entityAsset.RandomRotation)
                {
                    asteroid.Transform.Rotation = (float)((float)random.Next(0, 6300) / 1000f);
                }
            }

            //dynamic thing = Vector2.Zero;
            //dynamic number = 0;

            ValueFactory.GetValue<int>("1", out dynamic number);
            ValueFactory.GetValue<Vector2>("5,6", out dynamic thing);

            ProjectileWeaponComponent projectileWeaponComponent = new ProjectileWeaponComponent()
            {
                ProjectilesPerShot = number

            };
        }

        private void SetFaction(Entity entity, int factionID)
        {
            if(entity.HasComponent<FactionComponent>())
            {
                entity.GetComponent<FactionComponent>().FactionID = factionID;
            }
            else
            {
                entity.AddComponent(new FactionComponent() { FactionID = factionID });
            }
            
            if(entity.HasComponent<HardpointsComponent>())
            {
                HardpointsComponent hardpointsComponent = entity.GetComponent<HardpointsComponent>();

                foreach (Hardpoint hardpoint in hardpointsComponent.Hardpoints)
                {
                    SetFaction(EntityManager.Instance.GetEntity(hardpoint.EntityID), factionID);
                }
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            InputHandler.Instance.UpdateFirstValues();
            

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            
            if(InputHandler.Instance.KeyClicked(Keys.D7))
            {
                SystemManager.Instance.ToggleEnabled<SpriteDrawSystem>(false);
            }

            if (InputHandler.Instance.KeyDown(Keys.D8))
            {
                for (int i = 0; i < 40; i++)
                {

                    EntityAsset entityAsset = AssetStore.Instance.GetAsset<EntityAsset>("Asteroid");
                    Entity asteroid = EntityFactory.Instance.GetEntity(entityAsset.EntityData);
                    SetFaction(asteroid, 2);
                    asteroid.Transform.Position = RandomPosition();

                    if (entityAsset.RandomRotation)
                    {
                        asteroid.Transform.Rotation = (float)((float)random.Next(0, 6300) / 1000f);
                    }
                }
            }

            SystemManager.Instance.Update(gameTime);

            InputHandler.Instance.UpdateLastValues();
            EventManager.Instance.ProcessEvents(gameTime);
            base.Update(gameTime);
        }

        private Vector2 RandomPosition()
        {
            Vector2 position = Vector2.Zero;

            if (random.Next(0, 2) == 0)
            {
                if (random.Next(0, 2) == 0)
                {
                    position.X = random.Next(0, 800);
                    position.Y = -10;
                }
                else
                {
                    position.X = random.Next(0, 800);
                    position.Y = 810;
                }
            }
            else
            {
                if (random.Next(0, 2) == 0)
                {
                    position.X = -10;
                    position.Y = random.Next(0, 800);
                }
                else
                {
                    position.X = 810;
                    position.Y = random.Next(0, 800);
                }
            }

            return position;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SystemManager.Instance.Draw(spriteBatch);   

            base.Draw(gameTime);
        }
    }
}
