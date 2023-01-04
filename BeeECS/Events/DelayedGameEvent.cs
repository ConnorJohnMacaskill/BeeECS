using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeECS.Events
{
    class DelayedGameEvent
    {
        public GameEvent GameEvent { get; set; }
        public double Delay { get; set; }
    }
}
