namespace Decisions.TruCap.Steps;

public class DocumentMonitorSteps {
    public void GetDocumentMonitorListByDetails(string overrideBaseUrl, TruCapAuthentication authentication, string project = "Default", string docSubType = "Default", DateTime startDate, DateTime endDate) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/monitor/Project/{project}/DocumentSubType/{docSubType}/FromDate/2022-12-22/ToDate/2023-12-01/Status/MI,QC");
        request.Headers.Add("sid", "");
        request.Headers.Add("token", "");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

    }

    public void GetDocumentMonitorListByDocumentHeaderId(string overrideBaseUrl, TruCapAuthentication authentication, string documentHeaderId) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/monitor/DocumentId/{documentHeaderId}");
        request.Headers.Add("sid", "");
        request.Headers.Add("token", "");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

    }

    public void GetDocumentMonitorListByParentId(string overrideBaseUrl, TruCapAuthentication authentication, string parentId) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/monitor/ParentId/{parentId}");
authentication.SetHeaders(authentication);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

    }

    public void GetDocumentMonitorListByDocumentName(string overrideBaseUrl, TruCapAuthentication authentication, string documentName) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/monitor/DocumentName/{documentName}");
authentication.SetHeaders(authentication);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

    }
}