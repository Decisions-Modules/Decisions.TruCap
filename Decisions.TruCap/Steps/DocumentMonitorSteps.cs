using Decisions.TruCap.Api;
using Decisions.TruCap.Data;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Flow.StepImplementations;
using DecisionsFramework.ServiceLayer;
using Newtonsoft.Json;

namespace Decisions.TruCap.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/TruCap/Document Monitor")]
    [ShapeImageAndColorProvider(null, TruCapSettings.TRUCAP_IMAGES_PATH)]
    public class DocumentMonitorSteps
    {
        public List<DocumentMonitorResponse> GetDocumentMonitorListByDetails(string overrideBaseUrl,
            TruCapAuthentication authentication, DateTime startDate, DateTime endDate, string project = "Default",
            string docSubType = "Default")
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentMonitorUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet(
                $"{baseUrl}/Project/{project}/DocumentSubType/{docSubType}/FromDate/2022-12-22/ToDate/2023-12-01/Status/MI,QC",
                authentication);

            return JsonConvert.DeserializeObject<List<DocumentMonitorResponse>>(response.Result.ToString());
        }

        public List<DocumentMonitorResponse> GetDocumentMonitorListByDocumentHeaderId(string overrideBaseUrl,
            TruCapAuthentication authentication, string documentHeaderId)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentMonitorUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/DocumentId/{documentHeaderId}", authentication);

            return JsonConvert.DeserializeObject<List<DocumentMonitorResponse>>(response.Result.ToString());
        }

        public List<DocumentMonitorResponse> GetDocumentMonitorListByParentId(string overrideBaseUrl,
            TruCapAuthentication authentication, string parentId)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentMonitorUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/ParentId/{parentId}", authentication);

            return JsonConvert.DeserializeObject<List<DocumentMonitorResponse>>(response.Result.ToString());
        }

        public List<DocumentMonitorResponse> GetDocumentMonitorListByDocumentName(string overrideBaseUrl,
            TruCapAuthentication authentication, string documentName)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentMonitorUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/DocumentName/{documentName}", authentication);

            return JsonConvert.DeserializeObject<List<DocumentMonitorResponse>>(response.Result.ToString());
        }
    }
}