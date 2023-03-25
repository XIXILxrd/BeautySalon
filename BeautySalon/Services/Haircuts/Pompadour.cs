using System.Xml.Serialization;

namespace BeautySalon.Services.Haircuts
{
    [XmlInclude(typeof(Pompadour))]
    [Serializable]

    public class Pompadour : Haircut
    {

        public Pompadour(string name, string type, double price, string description) : base(name, type, price, description)
        {
        }

        public Pompadour() { }
    }
}
