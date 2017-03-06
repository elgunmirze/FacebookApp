namespace FacebookApp.Interfaces.Services
{
    public interface IFacebookAppClient
    {
        T GetAll<T>(string accessToken, string path);
    }
}