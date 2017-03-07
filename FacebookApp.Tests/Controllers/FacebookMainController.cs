using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using FacebookApp.Common.Constants;
using FacebookApp.Interfaces.Facades;
using FacebookApp.Models.Models;
using FacebookApp.Services.Facades;
using FacebookApp.WebSite.Controllers;
using Moq;
using MvcContrib.TestHelper;
using NUnit.Framework;

namespace FacebookApp.Tests.Controllers
{
    [TestFixture]
    public class FacebookMainController
    {
        private MainController _mainController;
        private ICommonFacade _commonFacade;

        [OneTimeSetUp]
        public void OnTimeSetUp()
        {
            _commonFacade = new CommonFacade();
            _mainController = new MainController(_commonFacade);
        }



        [Test]
        public void Given_Index_Action_Result_View_Test()
        {
            //arrange
            var list = new List<FacebookInfo>
            {
                new FacebookInfo()
                {
                    Email = "elgun.",
                    FirstName = "sda",
                    Gender = "sdfdsfds",
                    TimeZone = 1,
                    Verified = true,
                    Locale = "az",
                    Link = "www.google.com",
                    LastName = "dsfdsf"
                }
            };

            ICommonFacade facedae = new CommonFacade();
            MainController mainc = new MainController(facedae);
            TestControllerBuilder builder = new TestControllerBuilder();
            builder.InitializeController(mainc);
            

            mainc.Session[FacebookConstants.SessionMyInfo] = list;
            builder.Session[FacebookConstants.SessionMyInfo] = list;

            //act
            var result = mainc.Index() as ViewResult;
           


            //assert
            Assert.IsNotNull(result);
         //   Assert.AreEqual("Index",result.ViewName);
           // Assert.IsNotInstanceOf<FacebookInfo>(result.Model);
        }
 
    }
}
