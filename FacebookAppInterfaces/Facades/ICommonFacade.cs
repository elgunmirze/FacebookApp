namespace FacebookApp.Interfaces.Facades
{
    public interface ICommonFacade
    {
        string GetAppSettings(string key);
        void SetToSession(string key, object value);
        object GetFromSession(string key);
    }
}