namespace BeautySalon.Services
{
    [Serializable]
    public class Massage : Service
    {
        public Massage(string name, double price, string description) : base(name, price, description)
        {
        }
    }
}
