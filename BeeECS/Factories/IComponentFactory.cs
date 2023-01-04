using BeeECS.Components;
using System.Xml.Linq;

namespace BeeECS.Factories
{
    public interface IComponentFactory
    {
        IComponent CreateComponent(XElement componentData);
    }
}
