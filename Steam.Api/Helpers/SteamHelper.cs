using System;
using Newtonsoft.Json;

namespace Steam.Api.Helpers
{
    public class SteamHelper
    {
        private static string _publisherKey = Environment.GetEnvironmentVariable("STEAM_PUBLISHER_KEY");
        public static async Task<Dictionary<string, object>> GetUser(string ticket, UInt64 appId)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(new HttpMethod("GET"), "https://partner.steam-api.com/ISteamUserAuth/AuthenticateUserTicket/v1/?key=" + _publisherKey + "&appid=" + appId + "&ticket=" + ticket);
                var response = await httpClient.SendAsync(request);
                var responseData = await response.Content.ReadAsStringAsync();
                var responseDict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, object>>>>(responseData);
                if (responseDict == null || responseDict["response"].ContainsKey("error"))
                    return null;

                return responseDict["response"]["params"];
            }
        }
    }
}