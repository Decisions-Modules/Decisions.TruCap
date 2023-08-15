using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;

namespace Decisions.TruCap.Data
{
    [DataContract]
    [Writable]
    public class TruCapAuthentication
    {
        [DataMember]
        [WritableValue]
        public string token { get; set; }
        
        [DataMember]
        [WritableValue]
        public string sid { get; set; }

        public void SetHeaders(HttpRequestMessage request)
        {
            request.Headers.Add("sid", sid);
            request.Headers.Add("token", token);
        }
    }
}