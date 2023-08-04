// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Document
    {
        public int documentId { get; set; }
        public string documentNo { get; set; }
        public string fileName { get; set; }
        public string originalFileName { get; set; }
        public string originalFilePath { get; set; }
        public string originalFileBytes { get; set; }
        public string processedFilePath { get; set; }
        public string processedFileBytes { get; set; }
        public object parentDocumentId { get; set; }
        public string parentDocumentFilePath { get; set; }
        public string parentFileBytes { get; set; }
        public string documentStatus { get; set; }
        public string documentStatusReason { get; set; }
        public List<Field> fields { get; set; }
        public List<Table> tables { get; set; }
        public EmailMetaData emailMetaData { get; set; }
    }

    public class DocumentSubType
    {
        public int documentSubTypeId { get; set; }
        public string documentSubTypeCode { get; set; }
        public string documentSubTypeName { get; set; }
        public string projectCode { get; set; }
        public string projectName { get; set; }
        public List<Document> documents { get; set; }
    }

    public class EmailMetaData
    {
        public object sender { get; set; }
        public object to { get; set; }
        public object cc { get; set; }
        public object bcc { get; set; }
        public object subject { get; set; }
        public object dateAndTime { get; set; }
        public object emailContent { get; set; }
        public object countOfAttachment { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public int order { get; set; }
        public List<Value> values { get; set; }
    }

    public class GetDocumentDataResponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
        public int referenceNumber { get; set; }
        public string uploadFileName { get; set; }
        public string projectCode { get; set; }
        public string projectName { get; set; }
        public string label { get; set; }
        public string metaData { get; set; }
        public string clientTransactionNumber { get; set; }
        public object outputReferenceNumber { get; set; }
        public List<DocumentSubType> documentSubType { get; set; }
    }

    public class Row
    {
        public int rowNo { get; set; }
        public List<Field> fields { get; set; }
    }

    public class Table
    {
        public string name { get; set; }
        public int order { get; set; }
        public List<Row> rows { get; set; }
    }

    public class Value
    {
        public string value { get; set; }
        public int confidence { get; set; }
        public int pageNo { get; set; }
        public int left { get; set; }
        public int top { get; set; }
        public int right { get; set; }
        public int bottom { get; set; }
        public int dedid { get; set; }
    }

