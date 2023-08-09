using Decisions.TruCap.Api;
using Decisions.TruCap.Data;
using DecisionsFramework.Design.Flow;
using Newtonsoft.Json;

namespace Decisions.TruCap.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/TruCap/Ontology")]
    public class OntologySteps
    {
        public async Task<List<OntologyResponse>> GetOntologyList(string overrideBaseUrl, TruCapAuthentication authentication)
        {
            Task<string?> response = TruCapRest.TruCapGet(
                overrideBaseUrl, $"/ontology", authentication);

            return JsonConvert.DeserializeObject<List<OntologyResponse>>(response.Result);
        }

        public async Task<OntologyDetailsResponse> GetOntologyDetails(string overrideBaseUrl, TruCapAuthentication authentication,
            string project, string docSubType)
        {
            Task<string?> response = TruCapRest.TruCapGet(
                overrideBaseUrl, $"/ontology/{project}/{docSubType}", authentication);

            return JsonConvert.DeserializeObject<OntologyDetailsResponse>(response.Result);
        }
    }
}