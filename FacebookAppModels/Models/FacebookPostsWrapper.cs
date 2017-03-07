using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FacebookApp.Models.Models
{
    [ExcludeFromCodeCoverage]
    public class FacebookPostsWrapper
    {
        public IList<FacebookPostsData> data { get; set; }
    }
}