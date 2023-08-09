using Decisions.TruCap.Api;
using Decisions.TruCap.Data;
using DecisionsFramework.Data.DataTypes;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.ServiceLayer;
using Newtonsoft.Json;

namespace Decisions.TruCap.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/TruCap/Document")]
    public class DocumentSteps
    {
        public async Task<DocumentDataResponse> UploadDocument(string overrideBaseUrl,
            TruCapAuthentication authentication, FileData file)
        {
            var client = new HttpClient();
            var url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            
            var request = new HttpRequestMessage(HttpMethod.Post, $"{url}document");
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
            Task<string?> response = TruCapRest.TruCapGet(
                overrideBaseUrl, $"/{documentId}", authentication);

            return JsonConvert.DeserializeObject<DocumentDataResponse>(response.Result);
        }

        public DocumentDataResponse GetDocumentDataByReferenceNumber(string overrideBaseUrl,
            TruCapAuthentication authentication, string referenceNumber)
        {
            Task<string?> response = TruCapRest.TruCapGet(
                overrideBaseUrl, $"/referencenumber/{referenceNumber}", authentication);

            return JsonConvert.DeserializeObject<DocumentDataResponse>(response.Result);
        }

        public DocumentDataResponse GetDocumentDataByLabel(string overrideBaseUrl,
            TruCapAuthentication authentication, string label)
        {
            Task<string?> response = TruCapRest.TruCapGet(
                overrideBaseUrl, $"/label/{label}", authentication);

            return JsonConvert.DeserializeObject<DocumentDataResponse>(response.Result);
        }

        public DocumentDataResponse GetDocumentDataByClientTransactionNumber(string overrideBaseUrl,
            TruCapAuthentication authentication, string transactionNumber)
        {
            Task<string?> response = TruCapRest.TruCapGet(
                overrideBaseUrl, $"/clientTransactionNumber/{transactionNumber}", authentication);

            return JsonConvert.DeserializeObject<DocumentDataResponse>(response.Result);
        }

        public DocumentStatusResponse GetDocumentStatusByDocumentId(string overrideBaseUrl,
            TruCapAuthentication authentication, string documentId)
        {
            Task<string?> response = TruCapRest.TruCapGet(
                overrideBaseUrl, $"/{documentId}/status", authentication);

            return JsonConvert.DeserializeObject<DocumentStatusResponse>(response.Result);
        }


        public DocumentStatusResponse GetDocumentStatusByReferenceNumber(string overrideBaseUrl,
            TruCapAuthentication authentication, string referenceNumber)
        {
            Task<string?> response = TruCapRest.TruCapGet(
                overrideBaseUrl, $"/referencenumber/{referenceNumber}/status", authentication);

            return JsonConvert.DeserializeObject<DocumentStatusResponse>(response.Result);
        }

        public DocumentStatusResponse GetDocumentStatusByLabel(string overrideBaseUrl,
            TruCapAuthentication authentication, string label)
        {
            Task<string?> response = TruCapRest.TruCapGet(
                overrideBaseUrl, $"/label/{label}/status", authentication);

            return JsonConvert.DeserializeObject<DocumentStatusResponse>(response.Result);
        }

        public DocumentStatusResponse GetDocumentStatusByClientTransactionNumber(string overrideBaseUrl,
            TruCapAuthentication authentication, string transactionNumber)
        {
            Task<string?> response = TruCapRest.TruCapGet(
                overrideBaseUrl, $"/clientTransactionNumber/{transactionNumber}/status", authentication);

            return JsonConvert.DeserializeObject<DocumentStatusResponse>(response.Result);
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