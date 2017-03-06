using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FacebookApp.Interfaces.Services;
using FacebookApp.Models.Models;
using FacebookApp.Tests.Constants;
using Moq;
using NUnit.Framework;

namespace FacebookApp.Tests.Services
{
    [TestFixture]
    [Category(FacebookConstantsTest.FacebookUnitTest)]
    public class FacebookClientTest
    {
        private Mock<IFacebookAppClient> _facebookClient;

        [OneTimeSetUp]
        public void OnTimeSetup()
        {
            _facebookClient = new Mock<IFacebookAppClient>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _facebookClient.Reset();
        }

        [Test]
        public void Given_Facebook_Access_Token_When_Requesting_My_Friends_Return_Friends_List()
        {
            //arrange
            var facebookFriendsList = new FacebookFriendsWrapper
            {
                data = new List<FacebookFriendsData>
                {
                    new FacebookFriendsData
                    {
                        id = "1",
                        name = "Elgun"
                    }
                }
            };

            //act
            _facebookClient.Setup(
                    p => p.GetAll<FacebookFriendsWrapper>(FacebookConstantsTest.AccessToken, FacebookConstantsTest.Path))
                .Returns(() => facebookFriendsList);


            //assert
            var friend = facebookFriendsList.data.First();
            Assert.That(friend.id, Is.EqualTo("1"));
            Assert.That(friend.name, Is.EqualTo("Elgun"));

            Assert.IsNotEmpty(facebookFriendsList.data);
            Assert.That(facebookFriendsList.data.Count, Is.Not.Null);
        }

        [Test]
        public void Given_Facebook_Access_Token_When_Requesting_My_Info_Return_Info_List()
        {
            //arrange
            var facebookInfoList = new FacebookInfoData
            {
                first_name = "Elgun",
                last_name = "Mirza",
                email = "elgun.mirza@accenture.com",
                gender = "Male",
                link = "google.com",
                locale = "AZ",
                timezone = 2,
                verified = true
            };

            //act
            _facebookClient.Setup(
                    p => p.GetAll<FacebookInfoData>(FacebookConstantsTest.AccessToken, FacebookConstantsTest.Path))
                .Returns(() => facebookInfoList);

            //assert
            Assert.That(facebookInfoList.first_name, Is.EqualTo("Elgun"));
            Assert.That(facebookInfoList.last_name, Is.EqualTo("Mirza"));

            Assert.IsNotEmpty(facebookInfoList.first_name, facebookInfoList.last_name, facebookInfoList.email);
            Assert.True(facebookInfoList.verified);
        }

        [Test]
        public void Given_Facebook_Access_Token_When_Requesting_My_Posts_Return_Post_List()
        {
            //arrange
            var facebookPostsList = new FacebookPostsWrapper
            {
                data = new List<FacebookPostsData>
                {
                    new FacebookPostsData
                    {
                        id = "1",
                        created_time = DateTime.ParseExact("25.02.2017", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                        story = "Something"
                    }
                }
            };

            //act
            _facebookClient.Setup(
                    p => p.GetAll<FacebookPostsWrapper>(FacebookConstantsTest.AccessToken, FacebookConstantsTest.Path))
                .Returns(() => facebookPostsList);


            //assert
            var post = facebookPostsList.data.First();
            Assert.That(post.id, Is.EqualTo("1"));
            Assert.That(post.story, Is.EqualTo("Something"));

            Assert.IsNotEmpty(facebookPostsList.data);
            Assert.That(facebookPostsList.data.Count, Is.Not.Null);
        }
    }
}