using System.Web.Mvc;
using FacebookApp.Common.Constants;
using FacebookApp.Common.Urls;
using FacebookApp.Interfaces.Adapters;
using FacebookApp.Interfaces.Facades;
using FacebookApp.Models.Models;
using FacebookApp.Services.Services;

namespace FacebookApp.WebSite.Controllers
{
    public class FacebookFriendsController : Controller
    {
        private readonly ICommonFacade _comfacade;
        private readonly FacebookAppClient _facebookAppClient;
        private readonly IFacebookFriendAdapter _facebookFriendAdapter;

        public FacebookFriendsController(
            ICommonFacade confacade,
            IFacebookFriendAdapter facebookFriendAdapter)
        {
            this._comfacade = confacade;
            this._facebookFriendAdapter = facebookFriendAdapter;
            this._facebookAppClient = new FacebookAppClient();
        }

        public ActionResult FriendsListPage()
        {
            var path = FacebookRequestUrls.FacebookFriendsUrl;
            var data =_facebookAppClient.GetAll<FacebookFriendsWrapper>(_comfacade.GetFromSession(FacebookConstants.SessionAccessToken).ToString(), path);
            var friendsList = _facebookFriendAdapter.FillMyFirends(data);
            this._comfacade.SetToSession(FacebookConstants.SessionFriendList, friendsList);
            return View(friendsList);
        }
    }
}