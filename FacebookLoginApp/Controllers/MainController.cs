using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;
using System.Web.SessionState;
using FacebookApp.Common.Constants;
using FacebookApp.Interfaces.Facades;
using FacebookApp.Models.Models;

namespace FacebookApp.WebSite.Controllers
{
    [ExcludeFromCodeCoverage]
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
           var infoList = this._comfacade.GetFromSession(FacebookConstants.SessionMyInfo) as List<FacebookInfo>;
           return View(infoList);
        }
    }
}