using BeautySalon.Collection;
using BeautySalon.Logger;
using BeautySalon.Serialization;
using BeautySalon.Services;
using BeautySalon.Services.Haircuts;

namespace BeautySalon
{
    class Program
    {
        public static void Main(string[] args)
        {
            LList<Service>? list = new LList<Service>();

            list.Add(new Pompadour(
                "B",
                "Default",
                1002.0,
                "Hello world"));
            list.Add(new Pixie(
                "D",
                "Default",
                1003.0,
                "Hello world"));
            list.Add(new Massage(
                "A",
                500.0,
                "hehsi"));
            list.Add(new HairColoring(
                "C color",
                123123121231,
                "Coloring hair in black"));

            list?.Display();

        }
    }
}