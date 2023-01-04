using ResBee.Assets;
using System.Xml.Linq;

namespace Asteroids.Assets
{
    class EntityAsset : Asset
    {
        public EntityAsset(string name, XElement entityData, bool randomRotation) : base(name)
        {
            EntityData = entityData;
            RandomRotation = randomRotation;
        }

        public XElement EntityData { get; private set; }

        public bool RandomRotation { get; private set; }
    }
}
