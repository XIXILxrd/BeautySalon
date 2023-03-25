using System.Xml.Serialization;

namespace BeautySalon.Services.Haircuts
{
    [XmlInclude(typeof(Haircut))]
    [Serializable]

    public abstract class Haircut : Service
    {
        public string? Type { get; set; }
        public Haircut(string name, string type, double price, string description) : base(name, price, description)
        {
            Name = name;
            Price = price;
            Description = description;
            Type = type;
        }

        public Haircut() { }
    }
}
