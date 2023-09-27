using Decisions.TruCap.Api;
using Decisions.TruCap.Data;
using DecisionsFramework;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Flow.StepImplementations;
using DecisionsFramework.Design.Properties;
using DecisionsFramework.ServiceLayer;

namespace Decisions.TruCap.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/TruCap+/Ontology")]
    [ShapeImageAndColorProvider(null, TruCapSettings.TRUCAP_IMAGES_PATH)]
    public class OntologySteps
    {
        public async Task<OntologyResponse[]> GetOntologyList(TruCapAuthentication authentication,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseOntologyUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet(baseUrl, authentication);

            return OntologyResponse.JsonDeserialize(await response.Result.Content.ReadAsStringAsync());
        }

        public async Task<OntologyDetailsResponse> GetOntologyDetails(TruCapAuthentication authentication, string project, string docSubType,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            if (string.IsNullOrEmpty(project))
            {
                throw new BusinessRuleException("project cannot be null or empty.");
            }
            
            if (string.IsNullOrEmpty(docSubType))
            {
                throw new BusinessRuleException("docSubType cannot be null or empty.");
            }
            
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseOntologyUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/{project}/{docSubType}", authentication);

            return OntologyDetailsResponse.JsonDeserialize(await response.Result.Content.ReadAsStringAsync());
        }
    }
}