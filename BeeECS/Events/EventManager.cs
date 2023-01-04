using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeECS.Events
{
    public class EventManager
    {
        private static EventManager instance;
        private Dictionary<Enum, Action<GameTime, GameEvent>> eventActions;
        private Queue<GameEvent> gameEventQueue;
        private List<DelayedGameEvent> delayedEvents;

        //Register events, need to create them or += to them.
        //Add events to queue.
        //

        public EventManager()
        {
            eventActions = new Dictionary<Enum, Action<GameTime, GameEvent>>();
            gameEventQueue = new Queue<GameEvent>();
            delayedEvents = new List<DelayedGameEvent>();
        }

        public static EventManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventManager();
                }

                return instance;
            }
        }

        public void RegisterAction(Enum eventID, Action<GameTime, GameEvent> eventAction)
        {
            if(eventActions.ContainsKey(eventID))
            {
                eventActions[eventID] += eventAction;
            }
            else
            {
                eventActions.Add(eventID, eventAction);
            }
        }

        public void DeregisterAction(Enum eventID, Action<GameTime, GameEvent> eventAction)
        {
            if(eventActions.ContainsKey(eventID))
            {
                eventActions[eventID] -= eventAction;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameEvent"></param>
        /// <param name="delay">The time in seconds before the event is processed.</param>
        public void QueueEvent(GameEvent gameEvent, double delay = 0)
        {
            if (delay > 0)
            {
                DelayedGameEvent delayedGameEvent = new DelayedGameEvent()
                {
                    GameEvent = gameEvent,
                    Delay = delay
                
                };

                delayedEvents.Add(delayedGameEvent);
            }
            else
            {
                //Process the event immediantly.
                gameEventQueue.Enqueue(gameEvent);
            }
        }

        /// <summary>
        /// Cancels any delayed events which will occur.
        /// </summary>
        /// <param name="id">The origin ID of the events to cancel.</param>
        public void CancelEvents(int originID)
        {
#warning Is there any reason this should also cancel events which are queued to process next frame?
            //Filter out the events we want to cancel.
            delayedEvents = delayedEvents.Where(x => x.GameEvent.OriginID != originID).ToList();
        }

        public void ProcessEvents(GameTime gameTime)
        {
            //Process the delayed events so they can be processed this frame if required.
            ProcessDelayedEvents(gameTime);

            while(gameEventQueue.Count > 0)
            {
                ProcessEvent(gameTime, gameEventQueue.Dequeue());
            }
        }

        private void ProcessDelayedEvents(GameTime gameTime)
        {
            //We are going to be iterating over the list backwards, so reverse the list first so we are still processing in the correct order.
            //List<DelayedGameEvent> reversedDelayedEvents = Enumerable.Reverse(delayedEvents).ToList();

            for(int i = delayedEvents.Count - 1; i >= 0; i--)
            {
                DelayedGameEvent delayedGameEvent = delayedEvents[i];
                delayedGameEvent.Delay -= gameTime.ElapsedGameTime.TotalSeconds;

                if (delayedGameEvent.Delay <= 0)
                {
                    gameEventQueue.Enqueue(delayedGameEvent.GameEvent);
                    delayedEvents.RemoveAt(i);
                }
            }
        }

        private void ProcessEvent(GameTime gameTime, GameEvent gameEvent)
        {
            Action<GameTime, GameEvent> action = null;

            if(eventActions.TryGetValue(gameEvent.EventType, out action))
            {
                action(gameTime, gameEvent);
            }
            else
            {
                //Probably shouldn't care if anything is subscribed to the event.
                //throw new Exception(string.Format("Attempted to process an event whose type '{0}' has no associated actions!", gameEvent.EventType));
            }
        }
    }
}
