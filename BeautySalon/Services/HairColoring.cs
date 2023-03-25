using BeautySalon.Services.Haircuts;
using System.Xml.Serialization;

namespace BeautySalon.Services
{
    [XmlInclude(typeof(HairColoring))]
    [Serializable]

    public class HairColoring : Service
    {
        public HairColoring(string name, double price, string description) : base(name, price, description)
        {
        }

        public HairColoring() { }
    }
}
