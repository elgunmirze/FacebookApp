using System.Collections.Generic;
using CuttingEdge.Conditions;
using FacebookApp.Interfaces.Adapters;
using FacebookApp.Models.Models;

namespace FacebookApp.Services.Adapters
{
    public class FacebookInfoAdapter : IFacebookInfoAdapter
    {
        public IList<FacebookInfo> FillMyInfo(FacebookInfoData facebookInfoData)
        {
            Condition.Requires(facebookInfoData, nameof(facebookInfoData)).IsNotNull();
            var infoList = new List<FacebookInfo>
            {
                new FacebookInfo
                {
                    Email = facebookInfoData.email,
                    FirstName = facebookInfoData.first_name,
                    Gender = facebookInfoData.gender,
                    LastName = facebookInfoData.last_name,
                    Link = facebookInfoData.link,
                    Locale = facebookInfoData.locale,
                    TimeZone = facebookInfoData.timezone,
                    Verified = facebookInfoData.verified
                }
            };
            return infoList;
        }
    }
}