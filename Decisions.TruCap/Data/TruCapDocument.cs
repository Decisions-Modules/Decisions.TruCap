using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;

namespace Decisions.TruCap.Data
{
    [DataContract]
    [Writable]
    public class TruCapDocument
    {
        [DataMember]
        [WritableValue]
        public string project { get; set; }

        [DataMember]
        [WritableValue]
        public string documentSubType { get; set; }

        [DataMember]
        [WritableValue]
        public string FilterDocumentSubType { get; set; }

        [DataMember]
        [WritableValue]
        public string fileName { get; set; }

        [DataMember]
        [WritableValue]
        public string filePath { get; set; }

        [DataMember]
        [WritableValue]
        public string label { get; set; }

        [DataMember]
        [WritableValue]
        public string? metaData { get; set; }

        [DataMember]
        [WritableValue]
        public bool isPrioritized { get; set; }

        [DataMember]
        [WritableValue]
        public bool waitForCompletion { get; set; }

        [DataMember]
        [WritableValue]
        public string miUserName { get; set; }
    }
}