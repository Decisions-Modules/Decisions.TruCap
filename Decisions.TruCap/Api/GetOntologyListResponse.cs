    namespace Decisions.TruCap.Api;
    
    public class GetOntologyListResponse
    {
        public int documentCategoryId { get; set; }
        public string documentCategoryName { get; set; }
        public int projectId { get; set; }
        public string projectName { get; set; }
        public int documentSubTypeId { get; set; }
        public string documentSubTypeName { get; set; }
    }