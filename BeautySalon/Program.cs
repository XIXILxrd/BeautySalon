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
            LList<Service> list = new LList<Service>();
            Serializer serializer = new Serializer(list);
            PrintLog printLog = new PrintLog();

            list.log.Display += printLog.ToConsole;
            serializer.log.Display += printLog.ToConsole;

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
                "Black color",
                11024.0,
                "Coloring hair in black"));

            serializer.ToXML("C:\\Users\\Public");

            list.Clear();

            list = serializer.FromXML("C:\\Users\\Public");

            list.Display();

        }
    }
}