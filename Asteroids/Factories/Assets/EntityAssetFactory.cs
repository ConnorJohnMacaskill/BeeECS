using Asteroids.Assets;
using ResBee.Assets;
using ResBee.Factories;
using System.Xml.Linq;

namespace Asteroids.Factories.Assets
{
    class EntityAssetFactory : IAssetFactory
    {
        public Asset CreateAsset(string filePath)
        {
            XElement element = XElement.Load(filePath);
            string name = element.Element("Name").Value;

            string rawRandomRotation = element.Element("RandomRotation")?.Value;

            if (bool.TryParse(rawRandomRotation, out bool randomRotation))
            {
            }

            EntityAsset entityAsset = new EntityAsset(name, element, randomRotation);
            return entityAsset;
        }
    }
}
