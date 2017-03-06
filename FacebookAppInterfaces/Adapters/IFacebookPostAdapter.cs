using System.Collections.Generic;
using FacebookApp.Models.Models;

namespace FacebookApp.Interfaces.Adapters
{
    public interface IFacebookPostAdapter
    {
        IList<FacebookPost> FillMyPosts(FacebookPostsWrapper data);
    }
}