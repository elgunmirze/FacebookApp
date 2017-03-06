using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookApp.Interfaces.Adapters;
using FacebookApp.Interfaces.Services;
using FacebookApp.Models.Models;
using FacebookApp.Services.Adapters;
using FacebookApp.Services.Services;
using FacebookApp.Tests.Constants;
using NUnit.Framework;

namespace FacebookApp.Tests.Services
{
    [Category("Unit Test")]
    public class FacebookAppTest
    {
        private FacebookAppClient _facebookAppClient;
        private ISessionServices _sessionServices;
        private IMyAdapter _myAdapter;

        [OneTimeSetUp]
        public void OmTimeSetup()
        {
            _sessionServices = new SessionServices();
            _facebookAppClient =new FacebookAppClient();
            _myAdapter = new MyAdapter();
        }

        [Test]
        [TestCase(TestConstants.ACCESS_TOKEN)]
        public void GetMyPersonalInformationTest(string accessToken)
        {
            //act
           dynamic data = _facebookAppClient.GetMyPersonalInformation(accessToken);
            //assert
           Assert.That(data,Is.Not.Empty);
           Assert.That(data.Count,Is.GreaterThan(0));
           Assert.IsInstanceOf<Facebook.JsonObject>(data);
        }

        [Test]
        [TestCase(TestConstants.ACCESS_TOKEN)]
        public void GetMyPostsTest(string accessToken)
        {
            //act
            dynamic data = _facebookAppClient.GetMyPosts(accessToken);
            //assert
            Assert.That(data, Is.Not.Empty);
            Assert.That(data.Count, Is.GreaterThan(0));
            Assert.IsInstanceOf<Facebook.JsonObject>(data);
        }

        [Test]
        [TestCase(TestConstants.ACCESS_TOKEN)]
        public void GetMyFriendsTest(string accessToken)
        {
            //act
            dynamic data = _facebookAppClient.GetMyFriends(accessToken);
            //assert
            Assert.That(data, Is.Not.Empty);
            Assert.That(data.Count, Is.GreaterThan(0));
            Assert.IsInstanceOf<Facebook.JsonObject>(data);
        }

        [Test]
        [TestCase(TestConstants.ACCESS_TOKEN)]
        public void SetPostsWithReactionNumberTest(string accessToken)
        {
            //arrange
            dynamic fbData = GetMyPostsTst(TestConstants.ACCESS_TOKEN);
            var fbList = new List<MyPosts>();

            //act
            List<MyPosts> myPostses= _facebookAppClient.SetPostsWithReactionNumber(fbList, accessToken);

            //assert
            Assert.That(myPostses, Is.Not.Empty);
            Assert.IsInstanceOf<List<MyPosts>>(myPostses);
            Assert.That(myPostses.Count, Is.GreaterThan(0));
            Assert.NotZero(myPostses.Count);
        }

        public dynamic GetMyPostsTst(string accessToken)
        {
            return _facebookAppClient.GetMyPosts(accessToken);
        }
    }
}
