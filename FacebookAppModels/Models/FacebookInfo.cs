using System.Diagnostics.CodeAnalysis;

namespace FacebookApp.Models.Models
{
    [ExcludeFromCodeCoverage]
    public class FacebookInfo
    {
        public string Link { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Locale { get; set; }
        public int TimeZone { get; set; }
        public bool Verified { get; set; }
    }
}