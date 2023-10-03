using Decisions.TruCap.Api;
using Decisions.TruCap.Data;
using DecisionsFramework;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Flow.StepImplementations;
using DecisionsFramework.Design.Properties;
using DecisionsFramework.ServiceLayer;

namespace Decisions.TruCap.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration/TruCap+/Document Monitor")]
    [ShapeImageAndColorProvider(null, TruCapSettings.TRUCAP_IMAGES_PATH)]
    public class DocumentMonitorSteps
    {
        public DocumentMonitorResponse[] GetDocumentMonitorListByDetails(TruCapAuthentication authentication,
            string startDate, string endDate, string project, string docSubType,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            if (string.IsNullOrEmpty(project))
            {
                throw new BusinessRuleException("project cannot be null or empty.");
            }
            
            if (string.IsNullOrEmpty(docSubType))
            {
                throw new BusinessRuleException("docSubType cannot be null or empty.");
            }
            
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentMonitorUrl(overrideBaseUrl);

            try
            {
                Task<string> resultTask = TruCapRest.TruCapGet(
                    $"{baseUrl}/Project/{project}/DocumentSubType/{docSubType}/FromDate/{startDate}/ToDate/{endDate}",
                    authentication);
                
                return DocumentMonitorResponse.JsonDeserialize(resultTask.Result);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleException("The request to TruCap+ was unsuccessful.", ex);
            }
        }

        public DocumentMonitorResponse[] GetDocumentMonitorListByDocumentHeaderId(TruCapAuthentication authentication, int documentId,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            if (documentId == null)
            {
                throw new BusinessRuleException("documentId cannot be null or empty.");
            }
            
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentMonitorUrl(overrideBaseUrl);

            try
            {
                Task<string> resultTask = TruCapRest.TruCapGet($"{baseUrl}/DocumentId/{documentId}", authentication);
                
                return DocumentMonitorResponse.JsonDeserialize(resultTask.Result);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleException("The request to TruCap+ was unsuccessful.", ex);
            }
        }

        public DocumentMonitorResponse[] GetDocumentMonitorListByParentId(TruCapAuthentication authentication, int parentId,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentMonitorUrl(overrideBaseUrl);

            try
            {
                Task<string> resultTask = TruCapRest.TruCapGet($"{baseUrl}/ParentId/{parentId}", authentication);
                
                return DocumentMonitorResponse.JsonDeserialize(resultTask.Result);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleException("The request to TruCap+ was unsuccessful.", ex);
            }
        }

        public DocumentMonitorResponse[] GetDocumentMonitorListByDocumentName(TruCapAuthentication authentication, string documentName,
            [PropertyClassification(0, "Override Base URL", "Settings")] string? overrideBaseUrl)
        {
            if (string.IsNullOrEmpty(documentName))
            {
                throw new BusinessRuleException("documentName cannot be null or empty.");
            }
            
            string baseUrl = ModuleSettingsAccessor<TruCapSettings>.GetSettings().GetBaseDocumentMonitorUrl(overrideBaseUrl);

            try
            {
                Task<string> resultTask = TruCapRest.TruCapGet($"{baseUrl}/DocumentName/{documentName}", authentication);
                
                return DocumentMonitorResponse.JsonDeserialize(resultTask.Result);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleException("The request to TruCap+ was unsuccessful.", ex);
            }
        }
    }
}