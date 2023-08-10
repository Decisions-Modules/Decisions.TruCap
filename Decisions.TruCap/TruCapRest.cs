using Decisions.TruCap.Data;

namespace Decisions.TruCap;

public class TruCapRest
{
    public static async Task<string?> TruCapGet(string url, TruCapAuthentication authentication)
    {
        //string url = $"{ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseUrl(urlOverride)}{urlExtension}";
        HttpClient client = new HttpClient();
        
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        authentication.SetHeaders(request);
        
        try
        {
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            return response.ToString();
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("timed out"))
            {
                throw new Exception("TruCap took too long to respond and has timed out.", ex);
            }

            throw;
        }
    }

    public static async Task<string?> TruCapDelete(string url, TruCapAuthentication authentication)
    {
        //string url = $"{ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseUrl(urlOverride)}{urlExtension}";
        HttpClient client = new HttpClient();

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);
        authentication.SetHeaders(request);

        try
        {
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            
            return response.ToString();
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("timed out"))
            {
                throw new Exception("TruCap took too long to respond and has timed out.", ex);
            }

            throw;
        }
    }
}