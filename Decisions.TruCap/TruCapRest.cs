using Decisions.TruCap.Data;
using DecisionsFramework;

namespace Decisions.TruCap;

public class TruCapRest
{
    public static HttpResponseMessage TruCapGet(string url, TruCapAuthentication authentication)
    {
        HttpClient client = new HttpClient();
        
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("sid", authentication.sid);
        request.Headers.Add("Authorization", $"Bearer {authentication.token}");
        
        try
        {
            HttpResponseMessage response = client.Send(request);

            return response;
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("timed out"))
            {
                throw new Exception("TruCap+ took too long to respond and has timed out.", ex);
            }

            throw new BusinessRuleException("The request to TruCap+ was unsuccessful.", ex);
        }
    }

    public static async Task<HttpResponseMessage> TruCapDelete(string url, TruCapAuthentication authentication)
    {
        HttpClient client = new HttpClient();

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);
        request.Headers.Add("sid", authentication.sid);
        request.Headers.Add("Authorization", $"Bearer {authentication.token}");

        try
        {
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            
            return response;
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("timed out"))
            {
                throw new Exception("TruCap+ took too long to respond and has timed out.", ex);
            }

            throw new BusinessRuleException("The request to TruCap+ was unsuccessful.", ex);
        }
    }
}