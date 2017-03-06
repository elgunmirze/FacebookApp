using System;
using System.Collections.Generic;
using CuttingEdge.Conditions;
using FacebookApp.Interfaces.Adapters;
using FacebookApp.Models.Models;

namespace FacebookApp.Services.Adapters
{
    public class FacebookFriendAdapter : IFacebookFriendAdapter
    {
        public IList<FacebookFirend> FillMyFirends(FacebookFriendsWrapper facebookFriendsData)
        {
            Condition.Requires(facebookFriendsData, nameof(facebookFriendsData)).IsNotNull();
            var friendsList = new List<FacebookFirend>();
            foreach (var v in facebookFriendsData.data)
                friendsList.Add(new FacebookFirend
                {
                    Id = v.id,
                    Name = v.name
                });
            return friendsList;
        }
    }
}