using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;

namespace Decisions.TruCap.Api
{
    [DataContract]
    [Writable]
    public class DocumentMonitorResponse
    {
        [WritableValue]
        public int DocumentID { get; set; }
        
        [WritableValue]
        public string Category { get; set; }
        
        [WritableValue]
        public string Project { get; set; }
        
        [WritableValue]
        public string Subtype { get; set; }
        
        [WritableValue]
        public string DocumentName { get; set; }
        
        [WritableValue]
        public int ParentID { get; set; }
        
        [WritableValue]
        public string CurrentStage { get; set; }
        
        [WritableValue]
        public string Duration { get; set; }
        
        [WritableValue]
        public string DateReceived { get; set; }
        
        [WritableValue]
        public string Prioritized { get; set; }
        
        [WritableValue]
        public string UserAllocated { get; set; }
        
        [WritableValue]
        public string ReadabilityScore { get; set; }
        
        [WritableValue]
        public string NextAction { get; set; }
        
        [WritableValue]
        public string CurrentStageCode { get; set; }
    }
}