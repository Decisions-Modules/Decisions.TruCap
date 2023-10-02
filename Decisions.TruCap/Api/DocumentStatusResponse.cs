using System.Runtime.Serialization;
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

        public static DocumentStatusResponse[] JsonDeserialize(string json)
        {
            DocumentStatusResponse[] text = JsonConvert.DeserializeObject<DocumentStatusResponse[]>(json);
            return text;
        }
    }
}