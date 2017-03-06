using System.Collections.Generic;
using FacebookApp.Models.Models;

namespace FacebookApp.Interfaces.Adapters
{
    public interface IFacebookFriendAdapter
    {
        IList<FacebookFirend> FillMyFirends(FacebookFriendsWrapper data);
    }
}