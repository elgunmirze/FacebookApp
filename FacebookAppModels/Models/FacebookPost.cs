using System;

namespace FacebookApp.Models.Models
{
    public class FacebookPost
    {
        public string Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Story { get; set; }
        public int LikesCount { get; set; }
        public int TotalCount { get; set; }
    }
}