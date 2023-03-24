namespace BeautySalon.Services.Haircuts
{
    [Serializable]

    public class Pompadour : Haircut
    {

        public Pompadour(string name, string type, double price, string description) : base(name, type, price, description)
        {
        }
    }
}
