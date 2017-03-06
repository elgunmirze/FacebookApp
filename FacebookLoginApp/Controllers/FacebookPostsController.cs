using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FacebookApp.Common.Constants;
using FacebookApp.Common.Urls;
using FacebookApp.Interfaces.Adapters;
using FacebookApp.Interfaces.Facades;
using FacebookApp.Models.Models;
using FacebookApp.Services.Services;

namespace FacebookApp.WebSite.Controllers
{
    public class FacebookPostsController : Controller
    {
        private readonly ICommonFacade _comfacade;
        private readonly FacebookAppClient _facebookAppClient;
        private readonly IFacebookPostAdapter _facebookPostAdapter;

        public FacebookPostsController(ICommonFacade confacade, IFacebookPostAdapter facebookPostAdapter)
        {
            this._facebookPostAdapter = facebookPostAdapter;
            this._comfacade = confacade;
            this._facebookAppClient = new FacebookAppClient();
        }

        public ActionResult PostListPage()
        {
            var path = FacebookRequestUrls.FacebookPostsUrl;
            var facebookPostsList = this._facebookAppClient.GetAll<FacebookPostsWrapper>(this._comfacade.GetFromSession(FacebookConstants.SessionAccessToken).ToString(), path);
            var myPostsList = this._facebookPostAdapter.FillMyPosts(facebookPostsList);

            foreach (var v in myPostsList)
            {
                var likesCount =this._facebookAppClient.GetAll<FacebookLikesWrapper>(this._comfacade.GetFromSession(FacebookConstants.SessionAccessToken).ToString(),$"{v.Id}/{FacebookConstants.Likes}");
                v.LikesCount = likesCount.data.Count;
            }

            this._comfacade.SetToSession(FacebookConstants.SessionPostsList, myPostsList);

            return View(myPostsList);
        }

        public ActionResult Expand(string id)
        {
            var postsList = this._comfacade.GetFromSession(FacebookConstants.SessionPostsList) as List<FacebookPost>;
            var model = postsList?.FirstOrDefault(p => p.Id == id);

            return View(model);
        }
    }
}