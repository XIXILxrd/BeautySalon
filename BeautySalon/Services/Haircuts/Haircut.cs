namespace BeautySalon.Services.Haircuts
{
    [Serializable]

    public abstract class Haircut : Service
    {
        public string Type { get; set; }
        public Haircut(string name, string type, double price, string description) : base(name, price, description)
        {
            Name = name;
            Price = price;
            Description = description;
            Type = type;
        }
    }
}
