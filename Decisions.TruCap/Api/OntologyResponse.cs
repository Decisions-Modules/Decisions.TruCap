using System.Runtime.Serialization;
using DecisionsFramework;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.TruCap.Api
{
    [DataContract]
    [Writable]
    public class OntologyResponse
    {
        [WritableValue]
        [JsonProperty("documentCategoryId")]
        public int DocumentCategoryId { get; set; }
        
        [WritableValue]
        [JsonProperty("documentCategoryName")]
        public string DocumentCategoryName { get; set; }
        
        [WritableValue]
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
        
        [WritableValue]
        [JsonProperty("projectName")]
        public string ProjectName { get; set; }
        
        [WritableValue]
        [JsonProperty("documentSubTypeId")]
        public int DocumentSubTypeId { get; set; }
        
        [WritableValue]
        [JsonProperty("documentSubTypeName")]
        public string DocumentSubTypeName { get; set; }
        
        public static List<OntologyResponse> JsonDeserialize(string json)
        {
            try
            {
                List<OntologyResponse>? text = JsonConvert.DeserializeObject<List<OntologyResponse>>(json);
                return text;
            }
            catch (Exception e)
            {
                throw new BusinessRuleException(e.Message);
            }
        }
    }
}