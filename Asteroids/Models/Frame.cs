using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Models
{
    public sealed class Frame
    {
        public Frame(Rectangle dimensions, int duration)
        {
            Dimensions = dimensions;
            Duration = duration;
        }

        public Rectangle Dimensions { get; private set; }
        public int Duration { get; private set; }
        public int ElapsedDuration { get; set; }
    }
}
