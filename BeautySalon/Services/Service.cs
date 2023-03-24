namespace BeautySalon.Services
{
    [Serializable]
    public abstract class Service
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public Service(string name, double price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Name} - {Price} Rubles ({Description})";
        }
    }
}
