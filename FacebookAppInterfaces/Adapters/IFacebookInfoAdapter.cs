using System.Collections.Generic;
using FacebookApp.Models.Models;

namespace FacebookApp.Interfaces.Adapters
{
    public interface IFacebookInfoAdapter
    {
        IList<FacebookInfo> FillMyInfo(FacebookInfoData data);
    }
}