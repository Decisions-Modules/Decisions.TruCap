using System.Runtime.Serialization;
using DecisionsFramework;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.TruCap.Api
{
    [DataContract]
    [Writable]
    public class DocumentStatusResponse
    {
        [WritableValue]
        [JsonProperty("documentId")]
        public int DocumentId { get; set; }
        
        [WritableValue]
        [JsonProperty("referenceNumber")]
        public int ReferenceNumber { get; set; }
        
        [WritableValue]
        [JsonProperty("statusId")]
        public int StatusId { get; set; }
        
        [WritableValue]
        [JsonProperty("statusName")]
        public string StatusName { get; set; }
        
        [WritableValue]
        [JsonProperty("receivedDate")]
        public string ReceivedDate { get; set; }

        public static List<DocumentStatusResponse>? JsonDeserialize(string json)
        {
            try
            {
                List<DocumentStatusResponse>? text = JsonConvert.DeserializeObject<List<DocumentStatusResponse>>(json);
                return text;
            }
            catch (Exception e)
            {
                throw new BusinessRuleException(e.Message);
            }
        }
    }
}