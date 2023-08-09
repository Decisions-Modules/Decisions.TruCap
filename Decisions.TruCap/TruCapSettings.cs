using System.ComponentModel;
using System.Runtime.Serialization;
using DecisionsFramework;
using DecisionsFramework.Data.ORMapper;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using DecisionsFramework.ServiceLayer;
using DecisionsFramework.ServiceLayer.Actions;
using DecisionsFramework.ServiceLayer.Actions.Common;
using DecisionsFramework.ServiceLayer.Services.Accounts;
using DecisionsFramework.ServiceLayer.Services.Administration;
using DecisionsFramework.ServiceLayer.Services.Folder;
using DecisionsFramework.ServiceLayer.Utilities;

namespace Decisions.TruCap;

[ORMEntity("trucap_settings")]
[DataContract]
[Writable]
public class TruCapSettings : AbstractModuleSettings, IInitializable, INotifyPropertyChanged, IValidationSource
{
     // BaseUrl
     [ORMField]
     private string baseUrl = "https://localhost:44318/api/v2/";

     [DataMember]
     [WritableValue]
     public string BaseUrl
     {
         get => baseUrl;
         set
         {
             baseUrl = value;
             OnPropertyChanged(nameof(BaseUrl));
         }
     }

     public string GetBaseUrl(string? overrideBaseUrl) {
        var url = baseUrl;
        if (string.IsNullOrEmpty(overrideBaseUrl)) 
            url = overrideBaseUrl;

        return url;
    }

    public string GetBaseDocumentUrl(string overrideBaseUrl = null) 
    {
        var url = baseUrl;
        if (string.IsNullOrEmpty(overrideBaseUrl)) 
            url = overrideBaseUrl;

        return $"{url}document";
    }

    public string GetBaseOntologyUrl(string overrideUrl = null) {
        var url = baseUrl;
        if (string.IsNullOrEmpty(overrideUrl))
            url = overrideUrl;

        return $"{url}ontology";
    }


    public TruCapSettings()
    {
        this.EntityName = "TruCap Module Settings";
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void Initialize()
    {
        ModuleSettingsAccessor<TruCapSettings>.GetSettings();
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public ValidationIssue[] GetValidationIssues()
    {
        List<ValidationIssue> issues = new List<ValidationIssue>();

        return issues.ToArray();
    }
    
    public override BaseActionType[] GetActions(AbstractUserContext userContext, EntityActionType[] types)
    {
        List<BaseActionType> actions = new List<BaseActionType>();

        Account userAccount = userContext.GetAccount();

        FolderPermission permission = FolderService.GetAccountEffectivePermissionInternal(
            new SystemUserContext(), this.EntityFolderID, userAccount.AccountID);

        bool canAdministrate = FolderPermission.CanAdministrate == (FolderPermission.CanAdministrate & permission) ||
                                userAccount.GetUserRights<PortalAdministratorModuleRight>() != null ||
                                userAccount.IsAdministrator();

        if (canAdministrate)
        {
            actions.Add(new EditEntityAction(typeof(TruCapSettings), "Edit", "Edits TruCap Module Settings") 
            {
                IsDefaultGridAction = true,
                OkActionName = "SAVE",
                CancelActionName = null
            });
        }

        return actions.ToArray();
    }
    
    private void SaveSettings(AbstractUserContext userContext, object obj)
    {
        TruCapSettings settings = obj as TruCapSettings;
        ORM<TruCapSettings> orm = new ORM<TruCapSettings>();
        orm.Store(settings);
    }
}