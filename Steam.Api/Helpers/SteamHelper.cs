using System;
using Newtonsoft.Json;

namespace Steam.Api.Helpers
{
    public class SteamHelper
    {
        public static async Task<Dictionary<string, object>> GetUser(string ticket)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(new HttpMethod("GET"), "https://partner.steam-api.com/ISteamUserAuth/AuthenticateUserTicket/v1/?key=PUTKEY&appid=PUTAPPID&ticket=" + ticket);
                var response = await httpClient.SendAsync(request);
                var responseData = await response.Content.ReadAsStringAsync();
                var responseDict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, object>>>>(responseData);
                if (responseDict["response"].ContainsKey("error"))
                    return null;

                return responseDict["response"]["params"];
            }
        }
    }
}