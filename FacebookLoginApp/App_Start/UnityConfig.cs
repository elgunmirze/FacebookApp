using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using FacebookApp.Interfaces.Services;
using FacebookApp.Models.Models;
using FacebookApp.Services.Services;
using FacebookApp.Services.Adapters;
using FacebookApp.Interfaces.Adapters;
using FacebookApp.Interfaces.Facades;
using FacebookApp.Services.Facades;
using System.Diagnostics.CodeAnalysis;

namespace FacebookLoginApp
{
    [ExcludeFromCodeCoverage]
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IFacebookFriendAdapter, FacebookFriendAdapter>();
            container.RegisterType<IFacebookPostAdapter, FacebookPostAdapter>();
            container.RegisterType<IFacebookInfoAdapter, FacebookInfoAdapter>();
            container.RegisterType<ICommonFacade, CommonFacade>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}