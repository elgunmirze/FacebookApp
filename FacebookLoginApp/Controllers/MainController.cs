using System.Collections.Generic;
using System.Web.Mvc;
using FacebookApp.Common.Constants;
using FacebookApp.Interfaces.Facades;
using FacebookApp.Models.Models;

namespace FacebookApp.WebSite.Controllers
{
    public class MainController : Controller
    {
        private readonly ICommonFacade _comfacade;

        public MainController(
            ICommonFacade confacade)
        {
            this._comfacade = confacade;
        }

        public ActionResult Index()
        {
            var postsList = this._comfacade.GetFromSession(FacebookConstants.SessionMyInfo) as List<FacebookInfo>;
            return View(postsList);
        }
    }
}