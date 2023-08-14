using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;

namespace Decisions.TruCap.Data
{
    [DataContract]
    [Writable]
    public class TruCapAuthentication
    {
        [WritableValue]
        public string token { get; set; }
        
        [WritableValue]
        public string sid { get; set; }

        public void SetHeaders(HttpRequestMessage request)
        {
            request.Headers.Add("sid", sid);
            request.Headers.Add("token", token);
        }
    }
}