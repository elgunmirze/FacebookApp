using FacebookApp.Common.Constants;

namespace FacebookApp.Common.Urls
{
    public class FacebookRequestUrls
    {
        public static string FacebookInfoUrl = string.Format(FacebookConstants.MyInfo + "?fields=" +
                                                             FacebookConstants.Link + "," +
                                                             FacebookConstants.FirstName + "," +
                                                             FacebookConstants.Currency + "," +
                                                             FacebookConstants.LastName + "," +
                                                             FacebookConstants.Email + "," +
                                                             FacebookConstants.Gender + "," +
                                                             FacebookConstants.Locale + "," +
                                                             FacebookConstants.TimeZone + "," +
                                                             FacebookConstants.Verified + "," +
                                                             FacebookConstants.Picture + "," +
                                                             FacebookConstants.AgeRange + "," +
                                                             FacebookConstants.Posts + "," +
                                                             FacebookConstants.HomeTown + "," +
                                                             FacebookConstants.Location);

        public static string FacebookFriendsUrl = $"{FacebookConstants.MyInfo}/{FacebookConstants.TaggableFriends}";

        public static string FacebookPostsUrl = $"{FacebookConstants.MyInfo}/{FacebookConstants.Posts}";
    }
}