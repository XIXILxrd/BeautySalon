using System.Xml.Serialization;

namespace BeautySalon.Services.Haircuts
{
    [XmlInclude(typeof(Pixie))]
    [Serializable]

    public class Pixie : Haircut
    {
        public Pixie(string name, string type, double price, string description) : base(name, type, price, description)
        {
        }

        public Pixie() { }
    }
}
