using CuttingEdge.Conditions;
using Facebook;
using FacebookApp.Interfaces.Services;

namespace FacebookApp.Services.Services
{
    public class FacebookAppClient : FacebookClient, IFacebookAppClient
    {
        public T GetAll<T>(string accessToken, string path)
        {
            Condition.Requires(accessToken, nameof(accessToken)).IsNotNullOrWhiteSpace();
            Condition.Requires(path, nameof(path)).IsNotNullOrWhiteSpace();

            AccessToken = accessToken;
            return Get<T>(path);
        }
    }
}