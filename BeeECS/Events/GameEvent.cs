using BeeECS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeECS.Events
{
    public class GameEvent
    {
        private GameEvent()
        {

        }

        public GameEvent(Enum eventType, object data)
        {
            EventType = eventType;
            Data = data;
            OriginID = -1;
        }

        public GameEvent(Enum eventType, object data, int originID)
        {
            EventType = eventType;
            Data = data;
            OriginID = originID;
        }

        public Enum EventType { get; private set; }
        public object Data { get; private set; }
        public int OriginID { get; private set; }
    }
}
