namespace BeautySalon.Services.Haircuts
{
    [Serializable]

    public class Pixie : Haircut
    {
        public Pixie(string name, string type, double price, string description) : base(name, type, price, description)
        {
        }
    }
}
