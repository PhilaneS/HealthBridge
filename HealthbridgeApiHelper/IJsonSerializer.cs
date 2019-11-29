using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace HealthbridgeApiHelper
{
    public interface IJsonSerializer : ISerializer, IDeserializer
    {
    }
}
