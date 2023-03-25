using BeautySalon.Services.Haircuts;
using System.Xml.Serialization;

namespace BeautySalon.Services
{
    [XmlInclude(typeof(Massage))]
    [Serializable]
    public class Massage : Service
    {
        public Massage(string name, double price, string description) : base(name, price, description)
        {
        }
        
        public Massage() { }
    }
}
