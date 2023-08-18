using System.Runtime.Serialization;
using DecisionsFramework;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.TruCap.Api
{
    [DataContract]
    [Writable]
    public class Document
    {
        [WritableValue]
        [JsonProperty("documentId")]
        public int DocumentId { get; set; }
        
        [WritableValue]
        [JsonProperty("documentNo")]
        public string DocumentNo { get; set; }
        
        [WritableValue]
        [JsonProperty("fileName")]
        public string FileName { get; set; }
        
        [WritableValue]
        [JsonProperty("originalFileName")]
        public string OriginalFileName { get; set; }
        
        [WritableValue]
        [JsonProperty("originalFilePath")]
        public string OriginalFilePath { get; set; }
        
        [WritableValue]
        [JsonProperty("originalFileBytes")]
        public string OriginalFileBytes { get; set; }
        
        [WritableValue]
        [JsonProperty("processedFilePath")]
        public string ProcessedFilePath { get; set; }
        
        [WritableValue]
        [JsonProperty("processedFileBytes")]
        public string ProcessedFileBytes { get; set; }
        
        [WritableValue]
        [JsonProperty("parentDocumentId")]
        public string ParentDocumentId { get; set; }
        
        [WritableValue]
        [JsonProperty("parentDocumentFilePath")]
        public string ParentDocumentFilePath { get; set; }
        
        [WritableValue]
        [JsonProperty("parentFileBytes")]
        public string ParentFileBytes { get; set; }
        
        [WritableValue]
        [JsonProperty("documentStatus")]
        public string DocumentStatus { get; set; }
        
        [WritableValue]
        [JsonProperty("documentStatusReason")]
        public string DocumentStatusReason { get; set; }
        
        [WritableValue]
        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }
        
        [WritableValue]
        [JsonProperty("tables")]
        public List<Table> Tables { get; set; }
        
        [WritableValue]
        [JsonProperty("emailMetaData")]
        public EmailMetaData EmailMetaData { get; set; }
    }

    [DataContract]
    [Writable]
    public class DocumentSubType
    {
        [WritableValue]
        [JsonProperty("documentSubTypeId")]
        public int DocumentSubTypeId { get; set; }
        
        [WritableValue]
        [JsonProperty("documentSubTypeCode")]
        public string DocumentSubTypeCode { get; set; }
        
        [WritableValue]
        [JsonProperty("documentSubTypeName")]
        public string DocumentSubTypeName { get; set; }
        
        [WritableValue]
        [JsonProperty("projectCode")]
        public string ProjectCode { get; set; }
        
        [WritableValue]
        [JsonProperty("projectName")]
        public string ProjectName { get; set; }
        
        [WritableValue]
        [JsonProperty("documents")]
        public List<Document> Documents { get; set; }
    }

    [DataContract]
    [Writable]
    public class EmailMetaData
    {
        [WritableValue]
        [JsonProperty("sender")]
        public object Sender { get; set; }
        
        [WritableValue]
        [JsonProperty("to")]
        public object To { get; set; }
        
        [WritableValue]
        [JsonProperty("cc")]
        public object Cc { get; set; }
        
        [WritableValue]
        [JsonProperty("bcc")]
        public object Bcc { get; set; }
        
        [WritableValue]
        [JsonProperty("subject")]
        public object Subject { get; set; }
        
        [WritableValue]
        [JsonProperty("dateAndTime")]
        public object DateAndTime { get; set; }
        
        [WritableValue]
        [JsonProperty("emailContent")]
        public object EmailContent { get; set; }
        
        [WritableValue]
        [JsonProperty("countOfAttachment")]
        public object CountOfAttachment { get; set; }
    }

    [DataContract]
    [Writable]
    public class Field
    {
        [WritableValue]
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [WritableValue]
        [JsonProperty("order")]
        public int Order { get; set; }
        
        [WritableValue]
        [JsonProperty("values")]
        public List<Value> Values { get; set; }
    }

    [DataContract]
    [Writable]
    public class DocumentDataResponse
    {
        [WritableValue]
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        
        [WritableValue]
        [JsonProperty("statusMessage")]
        public string StatusMessage { get; set; }
        
        [WritableValue]
        [JsonProperty("referenceNumber")]
        public int ReferenceNumber { get; set; }
        
        [WritableValue]
        [JsonProperty("uploadFileName")]
        public string UploadFileName { get; set; }
        
        [WritableValue]
        [JsonProperty("projectCode")]
        public string ProjectCode { get; set; }
        
        [WritableValue]
        [JsonProperty("projectName")]
        public string ProjectName { get; set; }
        
        [WritableValue]
        [JsonProperty("label")]
        public string Label { get; set; }
        
        [WritableValue]
        [JsonProperty("metaData")]
        public string MetaData { get; set; }
        
        [WritableValue]
        [JsonProperty("clientTransactionNumber")]
        public string ClientTransactionNumber { get; set; }
        
        [WritableValue]
        [JsonProperty("outputReferenceNumber")]
        public object OutputReferenceNumber { get; set; }
        
        [WritableValue]
        [JsonProperty("documentSubType")]
        public List<DocumentSubType> DocumentSubType { get; set; }
        
        public static DocumentDataResponse? JsonDeserialize(string json)
        {
            try
            {
                DocumentDataResponse? text = JsonConvert.DeserializeObject<DocumentDataResponse>(json);
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
    public class Row
    {
        [WritableValue]
        [JsonProperty("rowNo")]
        public int RowNo { get; set; }
        
        [WritableValue]
        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }
    }

    [DataContract]
    [Writable]
    public class Table
    {
        [WritableValue]
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [WritableValue]
        [JsonProperty("order")]
        public int Order { get; set; }
        
        [WritableValue]
        [JsonProperty("rows")]
        public List<Row> Rows { get; set; }
    }

    [DataContract]
    [Writable]
    public class Value
    {
        [WritableValue]
        [JsonProperty("value")]
        public string FieldValue { get; set; }
        
        [WritableValue]
        [JsonProperty("confidence")]
        public int Confidence { get; set; }
        
        [WritableValue]
        [JsonProperty("pageNo")]
        public int PageNo { get; set; }
        
        [WritableValue]
        [JsonProperty("left")]
        public int Left { get; set; }
        
        [WritableValue]
        [JsonProperty("top")]
        public int Top { get; set; }
        
        [WritableValue]
        [JsonProperty("right")]
        public int Right { get; set; }
        
        [WritableValue]
        [JsonProperty("bottom")]
        public int Bottom { get; set; }
        
        [WritableValue]
        [JsonProperty("dedid")]
        public int Dedid { get; set; }
    }
}