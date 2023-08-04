using System.Net.Http.Headers;
using System.Text;
using Decisions.TruCap.Data;
using DecisionsFramework.ServiceLayer;

namespace Decisions.TruCap.Steps;

public class AuthSteps {
public TruCapAuthentication Login(string overrideBaseUrl, string username, string password) 
    {
        if (string.IsNullOrEmpty(username) )
            throw new ArgumentNullException(username);

        if (string.IsNullOrEmpty(password)) 
            throw new ArgumentNullException(password);

        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Post, $"{url}login");

        string credentials = $"{username}:{password}";
        byte[] credentialsBytes = Encoding.UTF8.GetBytes(credentials);
        string base64Credentials = Convert.ToBase64String(credentialsBytes);

        // Set the Authorization header
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", $"Basic {base64Credentials}");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync()); // as LoginResponse
        // Then convert to TruCapAuthentication to return

    }

    public bool IsLoggedIn(string overrideBaseUrl, TruCapAuthentication authentication) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Get, $"{url}login/status");
        authentication.SetHeaders(request);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());
        /*
            If login is live, then Status 200 returned.
            If login is expired, then Status 401 returned.
            Exception:
            Status 422 or 500 returned with message in response.
        */
    }

    public void Logout(string overrideBaseUrl, TruCapAuthentication authentication) {
        var client = new HttpClient();
        var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseUrl(overrideBaseUrl);
        var request = new HttpRequestMessage(HttpMethod.Delete, $"{url}logout");
authentication.SetHeaders(request);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());
        /*
            Status 200 OK is returned.
            Ignore exception?
        */
    }
}