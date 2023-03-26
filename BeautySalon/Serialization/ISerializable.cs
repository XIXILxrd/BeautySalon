using BeautySalon.Collection;
using BeautySalon.Services;

namespace BeautySalon.Serialization
{
    public interface ISerializable
    {
        public void ToJSON(string path);

        public void ToXML(string path);

        public LList<Service>? FromJSON(string path);

        public LList<Service>? FromXML(string path);

    }
}
