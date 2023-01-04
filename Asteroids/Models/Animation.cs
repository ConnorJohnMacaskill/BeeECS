using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Models
{
    public sealed class Animation
    {
        public Animation(string name, Frame[] frames)
        {
            Name = name;
            Frames = frames;
        }

        public string Name { get; private set; }
        public Frame[] Frames { get; private set; }
    }
}
