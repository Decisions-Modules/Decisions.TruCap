using System.Net.Http.Headers;
using System.Text;
using Decisions.TruCap.Api;
using Decisions.TruCap.Data;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Flow.StepImplementations;
using DecisionsFramework.ServiceLayer;
using Newtonsoft.Json;


namespace Decisions.TruCap.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/TruCap/Authentication")]
    [ShapeImageAndColorProvider(null, TruCapSettings.TRUCAP_IMAGES_PATH)]
    public class AuthSteps
    {
        public async Task<string> Login(string? overrideBaseUrl, string username, string password)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(username);

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(password);

            var client = new HttpClient();
            var baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseUrl(overrideBaseUrl);
            
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/login");

            string credentials = $"{username}:{password}";
            byte[] credentialsBytes = Encoding.UTF8.GetBytes(credentials);
            string base64Credentials = Convert.ToBase64String(credentialsBytes);

            // Set the Authorization header
            request.Headers.Add("Authorization", $"Basic {base64Credentials}");

            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync()); // as LoginResponse

                return await response.Content.ReadAsStringAsync();

                //return JsonConvert.DeserializeObject<LoginResponse>(response.Content.ReadAsStreamAsync().ToString());
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

        public bool IsLoggedIn(string? overrideBaseUrl, TruCapAuthentication authentication)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet(
                $"{baseUrl}/login/status?sid={authentication.sid}&token={authentication.token}", authentication);

            return response.Result.StatusCode.Equals("200");

            /*
                If login is live, then Status 200 returned.
                If login is expired, then Status 401 returned.
                Exception:
                Status 422 or 500 returned with message in response.
            */
        }

        public string? Logout(string? overrideBaseUrl, TruCapAuthentication authentication)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseUrl(overrideBaseUrl);
            return TruCapRest.TruCapDelete($"{baseUrl}/logout", authentication).Result.ToString();

            /*
                Status 200 OK is returned.
                Ignore exception?
            */
        }
    }
}