using Decisions.TruCap.Api;
using Decisions.TruCap.Data;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Flow.StepImplementations;
using DecisionsFramework.ServiceLayer;
using Newtonsoft.Json;

namespace Decisions.TruCap.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/TruCap/Ontology")]
    [ShapeImageAndColorProvider(null, TruCapSettings.TRUCAP_IMAGES_PATH)]
    public class OntologySteps
    {
        public async Task<List<OntologyResponse>> GetOntologyList(string overrideBaseUrl, TruCapAuthentication authentication)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseOntologyUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet(baseUrl, authentication);

            return JsonConvert.DeserializeObject<List<OntologyResponse>>(response.Result.ToString());
        }

        public async Task<OntologyDetailsResponse> GetOntologyDetails(string overrideBaseUrl, TruCapAuthentication authentication,
            string project, string docSubType)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseOntologyUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/{project}/{docSubType}", authentication);

            return JsonConvert.DeserializeObject<OntologyDetailsResponse>(response.Result.ToString());
        }
    }
}