using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FacebookApp.Models.Models
{
    [ExcludeFromCodeCoverage]
    public class FacebookFriendsWrapper
    {
        public IList<FacebookFriendsData> data { get; set; }
    }
}