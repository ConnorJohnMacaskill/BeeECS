using Asteroids.Assets;
using Asteroids.Components;
using BeeECS.Components;
using BeeECS.Entities;
using BeeECS.Factories;
using Microsoft.Xna.Framework;
using ResBee.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Asteroids.Factories.Components
{
    class HardpointsComponentFactory : IComponentFactory
    {
        public IComponent CreateComponent(XElement componentData)
        {
            List<Hardpoint> hardpoints = new List<Hardpoint>();

            XElement hardpointsElement = componentData.Element("Hardpoints");

            foreach(XElement hardpointElement in hardpointsElement.Elements())
            {
                hardpoints.Add(CreateHardPoint(hardpointElement));
            }

            return new HardpointsComponent()
            {
                Hardpoints = hardpoints
            };
        }

        private Hardpoint CreateHardPoint(XElement hardPointData)
        {
            string rawEntity = hardPointData.Element("Entity").Value;
            string rawOffset = hardPointData.Element("Offset").Value;

            EntityAsset entityAsset = AssetStore.Instance.GetAsset<EntityAsset>(rawEntity.Trim());
            Entity entity = EntityFactory.Instance.GetEntity(entityAsset.EntityData);
            Vector2 offSet = ValueFactory.GetVector2(rawOffset, true);

            return new Hardpoint()
            {
                EntityID = entity.ID,
                Offset = offSet
            };
        }
    }
}
