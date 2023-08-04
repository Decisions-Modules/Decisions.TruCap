using Decisions.TruCap.Api;
using Decisions.TruCap.Data;
using DecisionsFramework.ServiceLayer;

namespace Decisions.TruCap.Steps;

public class OntologySteps {
public GetOntologyListResponse GetOntologyList(string overrideBaseUrl, TruCapAuthentication authentication) {
    var client = new HttpClient();
    var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseOntologyUrl(overrideBaseUrl);
    var request = new HttpRequestMessage(HttpMethod.Get, url);
    authentication.SetHeaders(request);
    var response = await client.SendAsync(request);
    response.EnsureSuccessStatusCode();
    Console.WriteLine(await response.Content.ReadAsStringAsync());

}

public GetOntologyDetailsResponse GetOntologyDetails(string overrideBaseUrl, TruCapAuthentication authentication, string project, string docSubType) {
    var client = new HttpClient();
    var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseOntologyUrl(overrideBaseUrl);
    var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/{project}/{docSubType}");
    authentication.SetHeaders(request);
    var response = await client.SendAsync(request);
    response.EnsureSuccessStatusCode();
    Console.WriteLine(await response.Content.ReadAsStringAsync());

}
}
