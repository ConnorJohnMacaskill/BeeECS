using Asteroids.Components;
using BeeECS.Components;
using BeeECS.Factories;
using Logging;
using Logging.Enums;
using Microsoft.Xna.Framework;
using System.Xml.Linq;

namespace Asteroids.Factories.Components
{
    public class DragComponentFactory : IComponentFactory
    {
        public IComponent CreateComponent(XElement componentData)
        {
            string rawMovementDrag = componentData.Element("MovementDrag").Value;
            string rawRotationDrag = componentData.Element("RotationDrag").Value;
            float movementDrag = ValueFactory.GetFloat(rawMovementDrag, true);
            float rotationDrag = ValueFactory.GetFloat(rawRotationDrag, true);

            DragComponent rotateComponent = new DragComponent()
            {
                MovementDrag = movementDrag,
                RotationDrag = MathHelper.ToRadians(rotationDrag)
            };

            return rotateComponent;
        }
    }
}
