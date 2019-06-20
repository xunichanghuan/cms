using System.Collections;
using SS.CMS.Models;

namespace SS.CMS.Services
{
    public partial interface IPathManager
    {
        IDictionary ChannelRulesGetDictionary(SiteInfo siteInfo, int channelId);

        string ChannelRulesParse(SiteInfo siteInfo, int channelId);
    }
}