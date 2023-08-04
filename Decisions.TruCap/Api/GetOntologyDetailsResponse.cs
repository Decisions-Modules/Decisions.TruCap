// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class FooterField
    {
        public string fieldName { get; set; }
        public string baseDataType { get; set; }
        public int fieldIndex { get; set; }
    }

    public class HeaderField
    {
        public string fieldName { get; set; }
        public string baseDataType { get; set; }
        public int fieldIndex { get; set; }
    }

    public class GetOntologyDetailsResponse
    {
        public string documentCategoryName { get; set; }
        public string projectName { get; set; }
        public string documentSubTypeName { get; set; }
        public List<HeaderField> headerFields { get; set; }
        public List<FooterField> footerFields { get; set; }
        public List<Table> tables { get; set; }
    }

    public class Table
    {
        public int tableIndex { get; set; }
        public string tableName { get; set; }
        public List<TableField> tableFields { get; set; }
    }

    public class TableField
    {
        public string fieldName { get; set; }
        public string baseDataType { get; set; }
        public int fieldIndex { get; set; }
    }

