using System.Diagnostics.CodeAnalysis;

namespace FacebookApp.Models.Models
{
    [ExcludeFromCodeCoverage]
    public class FacebookInfoData
    {
        public string link { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string locale { get; set; }
        public int timezone { get; set; }
        public bool verified { get; set; }
    }
}