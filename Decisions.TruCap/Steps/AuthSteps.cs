using System.Text;
using Decisions.TruCap.Api;
using Decisions.TruCap.Data;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Flow.StepImplementations;
using DecisionsFramework.Design.Properties;
using DecisionsFramework.ServiceLayer;


namespace Decisions.TruCap.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/TruCap+/Authentication")]
    [ShapeImageAndColorProvider(null, TruCapSettings.TRUCAP_IMAGES_PATH)]
    public class AuthSteps
    {
        public LoginResponse Login(
            [PropertyClassification(0, "Username", "Credentials")]string username,
            [PropertyClassification(1, "Password", "Credentials")]string password,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
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
                HttpResponseMessage response = client.Send(request);
                response.EnsureSuccessStatusCode();

                return LoginResponse.JsonDeserialize(response.Content.ToString());
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("timed out"))
                {
                    throw new Exception("TruCap+ took too long to respond and has timed out.", ex);
                }

                throw;
            }
        }

        public bool IsLoggedIn(TruCapAuthentication authentication,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet(
                $"{baseUrl}/login/status?sid={authentication.sid}&token={authentication.token}", authentication);

            return response.Result.IsSuccessStatusCode;
        }

        public string? Logout(TruCapAuthentication authentication,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseUrl(overrideBaseUrl);
            HttpResponseMessage response = TruCapRest.TruCapDelete($"{baseUrl}/logout", authentication).Result;

            if (response.IsSuccessStatusCode)
            {
                return "Logout successful.";
            }

            return "Could not logout.";
        }
    }
}