using BeautySalon.Collection;
using BeautySalon.Logger;
using BeautySalon.Serialization;
using BeautySalon.Services;
using BeautySalon.Services.Haircuts;

namespace BeautySalon
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            PrintLog printLog = new PrintLog();
            LList<Service>? list = new LList<Service>();

            list.log.Display += printLog.ToConsole;

            list.Add(new Pompadour(
                "B",
                "Default",
                1002.0,
                "Pompadour"));
            list.Add(new Pixie(
                "D",
                "Default",
                1003.0,
                "Pixie"));
            list.Add(new Massage(
                "A",
                500.0,
                "Massage"));
            list.Add(new HairColoring(
                "C",
                123123121231,
                "HairColoring"));

            list = await list.Sort();

            list?.Display();
        }
    }
}