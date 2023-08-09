using Decisions.TruCap.Api;
using Decisions.TruCap.Data;
using DecisionsFramework.Design.Flow;
using Newtonsoft.Json;

namespace Decisions.TruCap.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/TruCap/Document Monitor")]
    public class DocumentMonitorSteps
    {
        public List<DocumentMonitorResponse> GetDocumentMonitorListByDetails(string overrideBaseUrl,
            TruCapAuthentication authentication, DateTime startDate, DateTime endDate, string project = "Default",
            string docSubType = "Default")
        {
            Task<string?> response = TruCapRest.TruCapGet(
                overrideBaseUrl,
                $"monitor/Project/{project}/DocumentSubType/{docSubType}/FromDate/2022-12-22/ToDate/2023-12-01/Status/MI,QC",
                authentication);

            return JsonConvert.DeserializeObject<List<DocumentMonitorResponse>>(response.Result);
        }

        public List<DocumentMonitorResponse> GetDocumentMonitorListByDocumentHeaderId(string overrideBaseUrl,
            TruCapAuthentication authentication, string documentHeaderId)
        {
            Task<string?> response = TruCapRest.TruCapGet(
                overrideBaseUrl, $"monitor/DocumentId/{documentHeaderId}", authentication);

            return JsonConvert.DeserializeObject<List<DocumentMonitorResponse>>(response.Result);
        }

        public List<DocumentMonitorResponse> GetDocumentMonitorListByParentId(string overrideBaseUrl,
            TruCapAuthentication authentication, string parentId)
        {
            Task<string?> response = TruCapRest.TruCapGet(
                overrideBaseUrl, $"monitor/ParentId/{parentId}", authentication);

            return JsonConvert.DeserializeObject<List<DocumentMonitorResponse>>(response.Result);
        }

        public List<DocumentMonitorResponse> GetDocumentMonitorListByDocumentName(string overrideBaseUrl,
            TruCapAuthentication authentication, string documentName)
        {
            Task<string?> response = TruCapRest.TruCapGet(
                overrideBaseUrl, $"monitor/DocumentName/{documentName}", authentication);

            return JsonConvert.DeserializeObject<List<DocumentMonitorResponse>>(response.Result);
        }
    }
}