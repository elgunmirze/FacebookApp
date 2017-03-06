using System;
using System.Collections.Generic;
using FacebookApp.Interfaces.Adapters;
using FacebookApp.Models.Models;
using CuttingEdge.Conditions;

namespace FacebookApp.Services.Adapters
{
    public class FacebookPostAdapter : IFacebookPostAdapter
    {
        public IList<FacebookPost> FillMyPosts(FacebookPostsWrapper facebookPostsData)
        {
            Condition.Requires(facebookPostsData, nameof(facebookPostsData)).IsNotNull();
            var postsList = new List<FacebookPost>();
            foreach (var v in facebookPostsData.data)
                postsList.Add(new FacebookPost
                {
                    Story = v.story,
                    CreatedTime = Convert.ToDateTime(v.created_time),
                    Id = v.id
                });
            return postsList;
        }
    }
}