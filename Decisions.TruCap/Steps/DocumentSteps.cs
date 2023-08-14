using Decisions.TruCap.Api;
using Decisions.TruCap.Data;
using DecisionsFramework.Data.DataTypes;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Flow.StepImplementations;
using DecisionsFramework.ServiceLayer;
using Newtonsoft.Json;

namespace Decisions.TruCap.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/TruCap/Document")]
    [ShapeImageAndColorProvider(null, TruCapSettings.TRUCAP_IMAGES_PATH)]
    public class DocumentSteps
    {
        public async Task<DocumentDataResponse> UploadDocument(string overrideBaseUrl,
            TruCapAuthentication authentication, FileData file)
        {
            var client = new HttpClient();
            var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            authentication.SetHeaders(request);

            var content = new MultipartFormDataContent();
            content.Add(
                new StreamContent(File.OpenRead("/C:/Users/mishra.sanjay/Desktop/Training 2023/EM10001112.tif")),
                "file", "/C:/Users/mishra.sanjay/Desktop/Training 2023/EM10001112.tif");
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

            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());

                return JsonConvert.DeserializeObject<DocumentDataResponse>(response.Content.ToString());
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
        
        public DocumentDataResponse GetDocumentDataByDocumentId(string overrideBaseUrl,
            TruCapAuthentication authentication, string documentId)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/{documentId}", authentication);

            return JsonConvert.DeserializeObject<DocumentDataResponse>(response.Result.ToString());
        }

        public DocumentDataResponse GetDocumentDataByReferenceNumber(string overrideBaseUrl,
            TruCapAuthentication authentication, string referenceNumber)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/referencenumber/{referenceNumber}", authentication);

            return JsonConvert.DeserializeObject<DocumentDataResponse>(response.Result.ToString());
        }

        public DocumentDataResponse GetDocumentDataByLabel(string overrideBaseUrl,
            TruCapAuthentication authentication, string label)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/label/{label}", authentication);

            return JsonConvert.DeserializeObject<DocumentDataResponse>(response.Result.ToString());
        }

        public DocumentDataResponse GetDocumentDataByClientTransactionNumber(string overrideBaseUrl,
            TruCapAuthentication authentication, string transactionNumber)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/clientTransactionNumber/{transactionNumber}", authentication);

            return JsonConvert.DeserializeObject<DocumentDataResponse>(response.Result.ToString());
        }

        public DocumentStatusResponse GetDocumentStatusByDocumentId(string overrideBaseUrl,
            TruCapAuthentication authentication, string documentId)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/{documentId}/status", authentication);

            return JsonConvert.DeserializeObject<DocumentStatusResponse>(response.Result.ToString());
        }


        public DocumentStatusResponse GetDocumentStatusByReferenceNumber(string overrideBaseUrl,
            TruCapAuthentication authentication, string referenceNumber)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/referencenumber/{referenceNumber}/status", authentication);

            return JsonConvert.DeserializeObject<DocumentStatusResponse>(response.Result.ToString());
        }

        public DocumentStatusResponse GetDocumentStatusByLabel(string overrideBaseUrl,
            TruCapAuthentication authentication, string label)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/label/{label}/status", authentication);

            return JsonConvert.DeserializeObject<DocumentStatusResponse>(response.Result.ToString());
        }

        public DocumentStatusResponse GetDocumentStatusByClientTransactionNumber(string overrideBaseUrl,
            TruCapAuthentication authentication, string transactionNumber)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/clientTransactionNumber/{transactionNumber}/status", authentication);

            return JsonConvert.DeserializeObject<DocumentStatusResponse>(response.Result.ToString());
        }

        public async Task<string> UpdateDocumentData(string overrideBaseUrl, TruCapAuthentication authentication)
        {
            HttpClient client = new HttpClient();
            string url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url);
            authentication.SetHeaders(request);

            StringContent content = new StringContent("", null, "text/plain");
            request.Content = content;

            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());

                return response.Content.ToString();
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
}