using System.Runtime.Serialization;
using DecisionsFramework;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.TruCap.Api
{
    [DataContract]
    [Writable]
    public class FooterField
    {
        [WritableValue]
        [JsonProperty("fieldName")]
        public string FieldName { get; set; }
        
        [WritableValue]
        [JsonProperty("baseDataType")]
        public string BaseDataType { get; set; }
        
        [WritableValue]
        [JsonProperty("fieldIndex")]
        public int FieldIndex { get; set; }
    }

    [DataContract]
    [Writable]
    public class HeaderField
    {
        [WritableValue]
        [JsonProperty("fieldName")]
        public string FieldName { get; set; }
        
        [WritableValue]
        [JsonProperty("baseDataType")]
        public string BaseDataType { get; set; }
        
        [WritableValue]
        [JsonProperty("fieldIndex")]
        public int FieldIndex { get; set; }
    }

    [DataContract]
    [Writable]
    public class OntologyDetailsResponse
    {
        [WritableValue]
        [JsonProperty("documentCategoryName")]
        public string DocumentCategoryName { get; set; }
        
        [WritableValue]
        [JsonProperty("projectName")]
        public string ProjectName { get; set; }
        
        [WritableValue]
        [JsonProperty("documentSubTypeName")]
        public string DocumentSubTypeName { get; set; }
        
        [WritableValue]
        [JsonProperty("headerFields")]
        public List<HeaderField> HeaderFields { get; set; }
        
        [WritableValue]
        [JsonProperty("footerFields")]
        public List<FooterField> FooterFields { get; set; }
        
        [WritableValue]
        [JsonProperty("tables")]
        public List<OntologyTable> Tables { get; set; }
        
        public static OntologyDetailsResponse? JsonDeserialize(string json)
        {
            try
            {
                OntologyDetailsResponse? text = JsonConvert.DeserializeObject<OntologyDetailsResponse>(json);
                return text;
            }
            catch (Exception e)
            {
                throw new BusinessRuleException(e.Message);
            }
        }
    }

    [DataContract]
    [Writable]
    public class OntologyTable
    {
        [WritableValue]
        [JsonProperty("tableIndex")]
        public int TableIndex { get; set; }
        
        [WritableValue]
        [JsonProperty("tableName")]
        public string TableName { get; set; }
        
        [WritableValue]
        [JsonProperty("tableFields")]
        public List<TableField> TableFields { get; set; }
    }

    [DataContract]
    [Writable]
    public class TableField
    {
        [WritableValue]
        [JsonProperty("fieldName")]
        public string FieldName { get; set; }
        
        [WritableValue]
        [JsonProperty("baseDataType")]
        public string BaseDataType { get; set; }
        
        [WritableValue]
        [JsonProperty("fieldIndex")]
        public int FieldIndex { get; set; }
    }
}
