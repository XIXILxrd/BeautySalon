namespace BeautySalon.Services
{
    [Serializable]

    class HairColoring : Service
    {
        public HairColoring(string name, double price, string description) : base(name, price, description)
        {
        }
    }
}
