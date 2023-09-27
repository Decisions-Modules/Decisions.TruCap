using System.Runtime.Serialization;
using DecisionsFramework;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.TruCap.Api
{
    [DataContract]
    [Writable]
    public class DocumentMonitorResponse
    {
        [WritableValue]
        [JsonProperty("DocumentID")]
        public int DocumentID { get; set; }
        
        [WritableValue]
        [JsonProperty("Category")]
        public string Category { get; set; }
        
        [WritableValue]
        [JsonProperty("Project")]
        public string Project { get; set; }
        
        [WritableValue]
        [JsonProperty("Subtype")]
        public string Subtype { get; set; }
        
        [WritableValue]
        [JsonProperty("DocumentName")]
        public string DocumentName { get; set; }
        
        [WritableValue]
        [JsonProperty("ParentID")]
        public int ParentID { get; set; }
        
        [WritableValue]
        [JsonProperty("CurrentStage")]
        public string CurrentStage { get; set; }
        
        [WritableValue]
        [JsonProperty("Duration")]
        public string Duration { get; set; }
        
        [WritableValue]
        [JsonProperty("DateReceived")]
        public string DateReceived { get; set; }
        
        [WritableValue]
        [JsonProperty("Prioritized")]
        public string Prioritized { get; set; }
        
        [WritableValue]
        [JsonProperty("UserAllocated")]
        public string UserAllocated { get; set; }
        
        [WritableValue]
        [JsonProperty("ReadabilityScore")]
        public string ReadabilityScore { get; set; }
        
        [WritableValue]
        [JsonProperty("NextAction")]
        public string NextAction { get; set; }
        
        [WritableValue]
        [JsonProperty("CurrentStageCode")]
        public string CurrentStageCode { get; set; }
        
        public static DocumentMonitorResponse[]? JsonDeserialize(string json)
        {
            try
            {
                DocumentMonitorResponse[]? text = JsonConvert.DeserializeObject<DocumentMonitorResponse[]>(json);
                return text;
            }
            catch (Exception e)
            {
                throw new BusinessRuleException(e.Message);
            }
        }
    }
}