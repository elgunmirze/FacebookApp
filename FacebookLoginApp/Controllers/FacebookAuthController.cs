using System;
using System.Web.Mvc;
using System.Web.Security;
using FacebookApp.Common.Constants;
using FacebookApp.Common.Urls;
using FacebookApp.Interfaces.Adapters;
using FacebookApp.Interfaces.Facades;
using FacebookApp.Models.Models;
using FacebookApp.Services.Services;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using FacebookApp.Common.Exception;

namespace FacebookApp.WebSite.Controllers
{
    [ExcludeFromCodeCoverage]
    public class FacebookAuthController : Controller
    {
        private readonly ICommonFacade _comfacade;
        private readonly FacebookAppClient _facebookAppClient;
        private readonly IFacebookInfoAdapter _facebookInfoAdapter;

        public FacebookAuthController(ICommonFacade comfacade, IFacebookInfoAdapter facebookInfoAdapter)
        {
            this._comfacade = comfacade;
            this._facebookInfoAdapter = facebookInfoAdapter;
            this._facebookAppClient = new FacebookAppClient();
        }

        private Uri RediredtUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url)
                {
                    Query = "",
                    Fragment = "",
                    Path = Url.Action(FacebookConstants.FacebookCallBack)
                };
                return uriBuilder.Uri;
            }
        }

        public ActionResult FacebookLogOut()
        {
            if (this._comfacade.GetFromSession(FacebookConstants.SessionAccessToken) != null)
            {
                this._comfacade.SetToSession(FacebookConstants.SessionAccessToken, null);
                FormsAuthentication.SignOut();
            }
            return RedirectToAction("LoginPage", "FacebookAuth");
        }

        [AllowAnonymous]
        public ActionResult FacebookLogIn()
        {
            var loginUrl = _facebookAppClient.GetLoginUrl(new
            {
                client_id = _comfacade.GetAppSettings(FacebookConstants.ClientId),
                client_secret = _comfacade.GetAppSettings(FacebookConstants.ClientSecret),
                redirect_uri = RediredtUri.AbsoluteUri,
                response_type = FacebookConstants.ResponseType,
                scope = FacebookConstants.Scope
            });
            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(code))
                {
                    var result = _facebookAppClient.Post(FacebookConstants.Oauth, new
                    {
                        client_id = _comfacade.GetAppSettings(FacebookConstants.ClientId),
                        client_secret = _comfacade.GetAppSettings(FacebookConstants.ClientSecret),
                        redirect_uri = RediredtUri.AbsoluteUri,
                        code
                    }).ToString();

                    var wrapper = JsonConvert.DeserializeObject<FacebookAccessLogin>(result);

                    this._comfacade.SetToSession(FacebookConstants.SessionAccessToken, wrapper.access_token);

                    var path = FacebookRequestUrls.FacebookInfoUrl;
                    var myInfo = _facebookAppClient.GetAll<FacebookInfoData>(wrapper.access_token, path);
                    var myInfoList = _facebookInfoAdapter.FillMyInfo(myInfo);
                    this._comfacade.SetToSession(FacebookConstants.SessionMyInfo, myInfoList);
                    return RedirectToAction("Index", "Main");
                }
                else
                {
                    throw new FacebookArgumentNullException("code is empty");
                }
            }
            catch(Exception exceptionMessage)
            {
                throw new FacebookArgumentNullException(exceptionMessage.Message);
            }
        }

        public ActionResult LoginPage()
        {
            return View();
        }
    }
}