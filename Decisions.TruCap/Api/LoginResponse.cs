using System.Runtime.Serialization;
using DecisionsFramework;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.TruCap.Api
{
    [DataContract]
    [Writable]
    public class LoginResponse
    {
        [WritableValue]
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }
        
        [WritableValue]
        [JsonProperty("token")]
        public string Token { get; set; }
        
        [WritableValue]
        [JsonProperty("message")]
        public string Message { get; set; }
        
        [WritableValue]
        [JsonProperty("sid")]
        public string Sid { get; set; }
        
        [WritableValue]
        [JsonProperty("validationUrl")]
        public string ValidationUrl { get; set; }
        
        public static LoginResponse? JsonDeserialize(string json)
        {
            try
            {
                LoginResponse? text = JsonConvert.DeserializeObject<LoginResponse>(json);
                return text;
            }
            catch (Exception e)
            {
                throw new BusinessRuleException(e.Message);
            }
        }
    }
}