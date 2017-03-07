using System;
using System.Diagnostics.CodeAnalysis;

namespace FacebookApp.Models.Models
{
    [ExcludeFromCodeCoverage]
    public class FacebookPostsData
    {
        public string id { get; set; }
        public string story { get; set; }
        public DateTime created_time { get; set; }
    }
}