using Decisions.TruCap.Api;
using Decisions.TruCap.Data;
using DecisionsFramework.Data.DataTypes;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Flow.StepImplementations;
using DecisionsFramework.Design.Properties;
using DecisionsFramework.ServiceLayer;
using Newtonsoft.Json;

namespace Decisions.TruCap.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/TruCap/Document")]
    [ShapeImageAndColorProvider(null, TruCapSettings.TRUCAP_IMAGES_PATH)]
    public class DocumentSteps
    {
        public async Task<DocumentDataResponse> UploadDocument(TruCapAuthentication authentication, FileData file, TruCapDocument documentData,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            HttpClient client = new HttpClient();
            string url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            authentication.SetHeaders(request);

            MultipartFormDataContent content = new MultipartFormDataContent();
            content.Add(
                new StreamContent(File.OpenRead("/C:/Users/mishra.sanjay/Desktop/Training 2023/EM10001112.tif")),
                "file", "/C:/Users/mishra.sanjay/Desktop/Training 2023/EM10001112.tif");
            content.Add(new StringContent(documentData.project), "Project");
            content.Add(new StringContent(documentData.documentSubType), "DocumentSubType");
            content.Add(new StringContent(documentData.FilterDocumentSubType), "FilterDocumentSubType");
            content.Add(new StringContent(documentData.fileName), "FileName");
            content.Add(new StringContent(documentData.filePath), "FilePath");
            content.Add(new StringContent(documentData.label), "Label");
            content.Add(new StringContent(documentData.metaData), "MetaData");
            content.Add(new StringContent(documentData.isPrioritized.ToString()), "IsPrioritized");
            content.Add(new StringContent(documentData.waitForCompletion.ToString()), "WaitForCompletion");
            content.Add(new StringContent(documentData.miUserName), "MIUserName");
            request.Content = content;

            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());

                return DocumentDataResponse.JsonDeserialize(await response.Content.ReadAsStringAsync());
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
        
        public async Task<DocumentDataResponse> GetDocumentDataByDocumentId(TruCapAuthentication authentication, string documentId,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/{documentId}", authentication);

            return DocumentDataResponse.JsonDeserialize(await response.Result.Content.ReadAsStringAsync());
        }

        public async Task<DocumentDataResponse> GetDocumentDataByReferenceNumber(TruCapAuthentication authentication, string referenceNumber,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/referencenumber/{referenceNumber}", authentication);

            return DocumentDataResponse.JsonDeserialize(await response.Result.Content.ReadAsStringAsync());
        }

        public async Task<DocumentDataResponse> GetDocumentDataByLabel(TruCapAuthentication authentication, string label,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/label/{label}", authentication);

            return DocumentDataResponse.JsonDeserialize(await response.Result.Content.ReadAsStringAsync());
        }

        public async Task<DocumentDataResponse> GetDocumentDataByClientTransactionNumber(TruCapAuthentication authentication, string transactionNumber,
        [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/clientTransactionNumber/{transactionNumber}", authentication);

            return DocumentDataResponse.JsonDeserialize(await response.Result.Content.ReadAsStringAsync());
        }

        public async Task<DocumentDataResponse> GetDocumentStatusByDocumentId(TruCapAuthentication authentication, string documentId,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/{documentId}/status", authentication);

            return DocumentDataResponse.JsonDeserialize(await response.Result.Content.ReadAsStringAsync());
        }


        public async Task<DocumentDataResponse> GetDocumentStatusByReferenceNumber(TruCapAuthentication authentication, string referenceNumber,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/referencenumber/{referenceNumber}/status", authentication);

            return DocumentDataResponse.JsonDeserialize(await response.Result.Content.ReadAsStringAsync());
        }

        public async Task<DocumentDataResponse> GetDocumentStatusByLabel(TruCapAuthentication authentication, string label,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/label/{label}/status", authentication);

            return DocumentDataResponse.JsonDeserialize(await response.Result.Content.ReadAsStringAsync());
        }

        public async Task<DocumentDataResponse> GetDocumentStatusByClientTransactionNumber(TruCapAuthentication authentication, string transactionNumber,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/clientTransactionNumber/{transactionNumber}/status", authentication);

            return DocumentDataResponse.JsonDeserialize(await response.Result.Content.ReadAsStringAsync());
        }

        public async Task<DocumentDataResponse> UpdateDocumentData(TruCapAuthentication authentication,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
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

                return DocumentDataResponse.JsonDeserialize(await response.Content.ReadAsStringAsync());
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