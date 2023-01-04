using Asteroids.Events;
using Asteroids.Utility;
using BeeECS.Events;
using BeeECS.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Asteroids.Systems
{
    class InputSystem : ECSystem, IUpdatableSystem
    {
        public InputSystem()
        {
            Requirements = null;
            Enabled = true;
        }


        public override SystemRequirements Requirements { get; set; }

        public void Update(GameTime gameTime)
        {
            if(InputHandler.Instance.KeyDown(Keys.W))
            {
                EventManager.Instance.QueueEvent(new GameEvent(InputEvent.MoveForwards, null));
            }

            if (InputHandler.Instance.KeyDown(Keys.S))
            {
                EventManager.Instance.QueueEvent(new GameEvent(InputEvent.MoveBackwards, null));
            }

            if (InputHandler.Instance.KeyDown(Keys.A))
            {
                EventManager.Instance.QueueEvent(new GameEvent(InputEvent.TurnLeft, null));
            }

            if (InputHandler.Instance.KeyDown(Keys.D))
            {
                EventManager.Instance.QueueEvent(new GameEvent(InputEvent.TurnRight, null));
            }

            if (InputHandler.Instance.KeyDown(Keys.Space))
            {
                EventManager.Instance.QueueEvent(new GameEvent(InputEvent.Shoot, null));
            }
        }
    }
}
