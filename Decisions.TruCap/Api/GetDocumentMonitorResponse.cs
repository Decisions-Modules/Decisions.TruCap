    public class GetDocumentMonitorResponse
    {
        public int DocumentID { get; set; }
        public string Category { get; set; }
        public string Project { get; set; }
        public string Subtype { get; set; }
        public string DocumentName { get; set; }
        public int ParentID { get; set; }
        public string CurrentStage { get; set; }
        public string Duration { get; set; }
        public string DateReceived { get; set; }
        public string Prioritized { get; set; }
        public string UserAllocated { get; set; }
        public string ReadabilityScore { get; set; }
        public string NextAction { get; set; }
        public string CurrentStageCode { get; set; }
    }

