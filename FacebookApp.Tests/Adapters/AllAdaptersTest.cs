using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FacebookApp.Interfaces.Adapters;
using FacebookApp.Models.Models;
using FacebookApp.Services.Adapters;
using FacebookApp.Tests.Constants;
using NUnit.Framework;
using CuttingEdge.Conditions;

namespace FacebookApp.Tests.Adapters
{
    [TestFixture(Category = FacebookConstantsTest.AdapterUnitTest)]
    public class AllAdaptersTest
    {
        private IFacebookPostAdapter _postAdapter;
        private IFacebookFriendAdapter _friendAdapter;
        private IFacebookInfoAdapter _infoAdapter;

        [OneTimeSetUp]
        public void ObjectInstanceSetup()
        {
            _postAdapter = new FacebookPostAdapter();
            _friendAdapter = new FacebookFriendAdapter();
            _infoAdapter = new FacebookInfoAdapter();
        }

        public void Given_null_facebook_list_when_FillMyFirends_then_throws()
        {
            Assert.Throws<ArgumentNullException>(() => _friendAdapter.FillMyFirends(null));
            Assert.Throws<Exception>(() => _friendAdapter.FillMyFirends(null));
        }
        public void Given_null_facebook_list_when_FillMyPosts_then_throws()
        {
            Assert.Throws<ArgumentNullException>(() => _postAdapter.FillMyPosts(null));
            Assert.Throws<Exception>(() => _friendAdapter.FillMyFirends(null));
        }
        public void Given_null_facebook_list_when_FillMyInfo_then_throws()
        {
            Assert.Throws<ArgumentNullException>(() => _infoAdapter.FillMyInfo(null));
            Assert.Throws<Exception>(() => _friendAdapter.FillMyFirends(null));
        }

        [Test]
        public void Given_Facebook_List_When_FillMyFirends_Then_Return_Friends_List()
        {
            // arrange
            var list = new FacebookFriendsWrapper
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

            // act

            IEnumerable<FacebookFirend> myFirendses = _friendAdapter.FillMyFirends(list);


            // assert
            Assert.That(myFirendses.Count, Is.EqualTo(1));

            var myFriend = myFirendses.First();
            Assert.That(myFriend.Id, Is.EqualTo("1"));
            Assert.That(myFriend.Name, Is.EqualTo("Elgun"));
            CollectionAssert.AllItemsAreNotNull(myFirendses);
        }

        [Test]
        public void  Given_Facebook_List_When_FillMyInfo_Then_Return_Info_List()
        {
            // act
            IEnumerable<FacebookInfo> myInfos = _infoAdapter.FillMyInfo(
            new FacebookInfoData()
            {
                timezone = 2,
                verified = true,
                gender = "Male",
                email = "elgun.mirza@accenture.com",
                locale = "Latvia",
                link = "www.google.com",
                last_name = "Mirza",
                first_name = "Elgun"
            });

            // assert
            Assert.IsNotEmpty(myInfos);
            Assert.That(myInfos.Count, Is.EqualTo(1));

            var info= myInfos.First();
            Assert.That(info.Email, Is.EqualTo("elgun.mirza@accenture.com"));
            Assert.That(info.Verified, Is.EqualTo(true));
            CollectionAssert.AllItemsAreNotNull(myInfos);
        }

        [Test]
        public void Given_Facebook_List_When_FillMyPosts_Then_Return_Post_List()
        {
            // arrange
            var list = new FacebookPostsWrapper
            {
                data = new List<FacebookPostsData>
                {
                    new FacebookPostsData
                    {
                        id = "1",
                        created_time = DateTime.ParseExact("25.02.2017", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                        story = "Hello World"
                    }
                }
            };

            // act
            var myPostses = _postAdapter.FillMyPosts(list);

            // assert
            var post = myPostses.First();
            Assert.That(post.Id, Is.EqualTo("1"));
            Assert.That(post.Story, Is.EqualTo("Hello World"));
            Assert.That(myPostses.Count, Is.EqualTo(1));
            Assert.IsNotEmpty(myPostses);
            CollectionAssert.AllItemsAreNotNull(myPostses);
        }
    }
}