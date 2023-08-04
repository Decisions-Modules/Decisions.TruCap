using Decisions.TruCap.Data;
using DecisionsFramework.ServiceLayer;

namespace Decisions.TruCap.Steps;

public class DocumentSteps {
        
    public UploadFilesResponse UploadDocument(string overrideBaseUrl, TruCapAuthentication authentication) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Post, url);
authentication.SetHeaders(request);
        var content = new MultipartFormDataContent();
        content.Add(new StreamContent(File.OpenRead("/C:/Users/mishra.sanjay/Desktop/Training 2023/EM10001112.tif")), "file", "/C:/Users/mishra.sanjay/Desktop/Training 2023/EM10001112.tif");
        content.Add(new StringContent("Default"), "Project");
        content.Add(new StringContent("Default"), "DocumentSubType");
        content.Add(new StringContent(""), "FilterDocumentSubType");
        content.Add(new StringContent(""), "FileName");
        content.Add(new StringContent(""), "FilePath");
        content.Add(new StringContent("EM01"), "Label");
        content.Add(new StringContent(""), "MetaData");
        content.Add(new StringContent(""), "IsPrioritized");
        content.Add(new StringContent(""), "WaitForCompletion");
        content.Add(new StringContent(""), "MIUserName");
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

    }


    public GetDocumentDataResponse GetDocumentDataByDocumentId(string overrideBaseUrl, TruCapAuthentication authentication, string documentId) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/{documentId}");
authentication.SetHeaders(request);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

    }

    public GetDocumentDataResponse GetDocumentDataByReferenceNumber(string overrideBaseUrl, TruCapAuthentication authentication, string referenceNumber) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/referencenumber/{referenceNumber}");
authentication.SetHeaders(request);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

    }

    public GetDocumentDataResponse GetDocumentDataByLabel(string overrideBaseUrl, TruCapAuthentication authentication, string label) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/label/{label}");
authentication.SetHeaders(request);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

    }

    public GetDocumentDataResponse GetDocumentDataByClientTransactionNumber(string overrideBaseUrl, TruCapAuthentication authentication, string transactionNumber) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/clientTransactionNumber/{transactionNumber}");
authentication.SetHeaders(request);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

    }

    public GetDocumentDataResponse GetDocumentStatusByDocumentId(string overrideBaseUrl, TruCapAuthentication authentication, string documentId) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/{documentId}/status");
authentication.SetHeaders(request);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

    }


    public GetDocumentDataResponse GetDocumentStatusByReferenceNumber(string overrideBaseUrl, TruCapAuthentication authentication, string referenceNumber) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/referencenumber/{referenceNumber}/status");
authentication.SetHeaders(request);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

    }

    public GetDocumentDataResponse GetDocumentStatusByLabel(string overrideBaseUrl, TruCapAuthentication authentication, string label) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/label/{label}/status");
authentication.SetHeaders(request);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

    }

    public GetDocumentDataResponse GetDocumentStatusByClientTransactionNumber(string overrideBaseUrl, TruCapAuthentication authentication, string transactionNumber) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/clientTransactionNumber/{transactionNumber}/status");
authentication.SetHeaders(request);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

    }

        public void UpdateDocumentData(string overrideBaseUrl, TruCapAuthentication authentication) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Put, url);
authentication.SetHeaders(request);
        var content = new StringContent("", null, "text/plain");
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

    }

}