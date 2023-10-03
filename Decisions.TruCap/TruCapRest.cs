using Decisions.TruCap.Data;
using DecisionsFramework;

namespace Decisions.TruCap;

public class TruCapRest
{
    public static string TruCapGet(string url, TruCapAuthentication authentication)
    {
        HttpClient client = new HttpClient();
        
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("sid", authentication.sid);
        request.Headers.Add("Authorization", $"Bearer {authentication.token}");
        
        HttpResponseMessage response = client.Send(request);
        response.EnsureSuccessStatusCode();

        Task<string> resultTask = response.Content.ReadAsStringAsync();
        resultTask.Wait();

        return resultTask.Result;
    }

    public static string TruCapDelete(string url, TruCapAuthentication authentication)
    {
        HttpClient client = new HttpClient();

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);
        request.Headers.Add("sid", authentication.sid);
        request.Headers.Add("Authorization", $"Bearer {authentication.token}");
        
        HttpResponseMessage response = client.Send(request);
        response.EnsureSuccessStatusCode();
        
        Task<string> resultTask = response.Content.ReadAsStringAsync();
        resultTask.Wait();
        
        return resultTask.Result;
    }
}