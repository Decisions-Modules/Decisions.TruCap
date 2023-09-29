using Decisions.TruCap.Api;
using Decisions.TruCap.Data;
using DecisionsFramework;
using DecisionsFramework.Data.DataTypes;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Flow.StepImplementations;
using DecisionsFramework.Design.Properties;
using DecisionsFramework.ServiceLayer;
using Newtonsoft.Json;

namespace Decisions.TruCap.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/TruCap+/Document")]
    [ShapeImageAndColorProvider(null, TruCapSettings.TRUCAP_IMAGES_PATH)]
    public class DocumentSteps
    {
        public DocumentDataResponse UploadDocument(TruCapAuthentication authentication, FileData file, TruCapDocument documentData,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            HttpClient client = new HttpClient();
            string url = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("sid", authentication.sid);
            request.Headers.Add("Authorization", $"Bearer {authentication.token}");

            MultipartFormDataContent content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(file.Contents), "file", file.FileName);
            if (documentData.project != null)
                content.Add(new StringContent(documentData.project), "Project");
            if (documentData.documentSubType != null)
                content.Add(new StringContent(documentData.documentSubType), "DocumentSubType");
            if (documentData.FilterDocumentSubType != null)
                content.Add(new StringContent(documentData.FilterDocumentSubType), "FilterDocumentSubType");
            if (documentData.label != null)
                content.Add(new StringContent(documentData.label), "Label");
            if (documentData.metaData != null)
                content.Add(new StringContent(documentData.metaData), "MetaData");
            content.Add(new StringContent(documentData.isPrioritized.ToString()), "IsPrioritized");
            content.Add(new StringContent(documentData.waitForCompletion.ToString()), "WaitForCompletion");
            if (documentData.miUserName != null)
                content.Add(new StringContent(documentData.miUserName), "MIUserName");
            
            request.Content = content;

            try
            {
                HttpResponseMessage response = client.Send(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(response.Content.ReadAsStringAsync());

                return DocumentDataResponse.JsonDeserialize(response.Content.ToString());
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
        
        public DocumentDataResponse GetDocumentDataByDocumentId(TruCapAuthentication authentication, string documentId,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            if (string.IsNullOrEmpty(documentId))
            {
                throw new BusinessRuleException("documentId cannot be null or empty.");
            }
            
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/{documentId}", authentication);

            try
            {
                return DocumentDataResponse.JsonDeserialize(response.Result.Content.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(response.Result.Content.ToString());
            }
        }

        public DocumentDataResponse GetDocumentDataByReferenceNumber(TruCapAuthentication authentication, string referenceNumber,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            if (string.IsNullOrEmpty(referenceNumber))
            {
                throw new BusinessRuleException("referenceNumber cannot be null or empty.");
            }
            
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/referencenumber/{referenceNumber}", authentication);

            try
            {
                return DocumentDataResponse.JsonDeserialize(response.Result.Content.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(response.Result.Content.ToString());
            }
        }

        public DocumentDataResponse GetDocumentDataByLabel(TruCapAuthentication authentication, string label,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            if (string.IsNullOrEmpty(label))
            {
                throw new BusinessRuleException("label cannot be null or empty.");
            }
            
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/label/{label}", authentication);

            try
            {
                return DocumentDataResponse.JsonDeserialize(response.Result.Content.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(response.Result.Content.ToString());
            }
        }

        public DocumentDataResponse GetDocumentDataByClientTransactionNumber(TruCapAuthentication authentication, string clientTransactionNumber,
        [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            if (string.IsNullOrEmpty(clientTransactionNumber))
            {
                throw new BusinessRuleException("clientTransactionNumber cannot be null or empty.");
            }
            
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/clientTransactionNumber/{clientTransactionNumber}", authentication);

            try
            {
                return DocumentDataResponse.JsonDeserialize(response.Result.Content.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(response.Result.Content.ToString());
            }
        }

        public DocumentStatusResponse[] GetDocumentStatusByDocumentId(TruCapAuthentication authentication, string documentId,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            if (string.IsNullOrEmpty(documentId))
            {
                throw new BusinessRuleException("documentId cannot be null or empty.");
            }
            
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/{documentId}/status", authentication);

            try
            {
                return DocumentStatusResponse.JsonDeserialize(response.Result.Content.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(response.Result.Content.ToString());
            }
        }


        public DocumentStatusResponse[] GetDocumentStatusByReferenceNumber(TruCapAuthentication authentication, string referenceNumber,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            if (string.IsNullOrEmpty(referenceNumber))
            {
                throw new BusinessRuleException("referenceNumber cannot be null or empty.");
            }
            
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/referencenumber/{referenceNumber}/status", authentication);

            try
            {
                return DocumentStatusResponse.JsonDeserialize(response.Result.Content.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(response.Result.Content.ToString());
            }
        }

        public DocumentStatusResponse[] GetDocumentStatusByLabel(TruCapAuthentication authentication, string label,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            if (string.IsNullOrEmpty(label))
            {
                throw new BusinessRuleException("label cannot be null or empty.");
            }
            
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/label/{label}/status", authentication);

            try
            {
                return DocumentStatusResponse.JsonDeserialize(response.Result.Content.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(response.Result.Content.ToString());
            }
        }

        public DocumentStatusResponse[] GetDocumentStatusByClientTransactionNumber(TruCapAuthentication authentication, string clientTransactionNumber,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            if (string.IsNullOrEmpty(clientTransactionNumber))
            {
                throw new BusinessRuleException("clientTransactionNumber cannot be null or empty.");
            }
            
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentUrl(overrideBaseUrl);
            Task<HttpResponseMessage> response = TruCapRest.TruCapGet($"{baseUrl}/clientTransactionNumber/{clientTransactionNumber}/status", authentication);

            try
            {
                return DocumentStatusResponse.JsonDeserialize(response.Result.Content.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(response.Result.Content.ToString());
            }
        }
    }
}