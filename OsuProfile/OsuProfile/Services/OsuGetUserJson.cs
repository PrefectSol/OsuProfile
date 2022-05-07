namespace OsuProfile.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;

    public class OsuGetUserJson
    {
        private const string API_URL = "https://osu.ppy.sh/api/v2";
        private const string TOKEN_URL = "https://osu.ppy.sh/oauth/token";

        private const string Secret = "C1T7Sl6YpIKBVY3eJSgPATbPcnq0nAIBEHSNJP60";
        private const string Id = "14533";
        private static string token;

        public static JObject Json = null;
        public static string UserID = null;

        public static async Task GetJson(string username)
        {
            await SetToken();
            try
            {
                string address = $"{API_URL}/users/{username}";

                WebClient client = new WebClient();

                client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("Accept", "application/json");
                client.Headers.Add("Authorization", $"Bearer {token}");

                client.QueryString.Add("mode", "osu");
                client.QueryString.Add("limit", "1");

                Stream data = client.OpenRead(address);
                StreamReader reader = new StreamReader(data);
                string responseString = reader.ReadToEnd();
                Json = JObject.Parse(responseString);

                UserID = Json["id"].ToString();

                data.Close();
                reader.Close();
            }
            catch
            {
                UserID = "error";
            }
        }

        private static async Task SetToken()
        {
            HttpClient client = new HttpClient();

            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                { "client_id", Id },
                { "client_secret", Secret },
                { "grant_type", "client_credentials" },
                { "scope", "public" },
            };

            FormUrlEncodedContent dataContent = new FormUrlEncodedContent(data);
            HttpResponseMessage response = await client.PostAsync(TOKEN_URL, dataContent);
            string responseString = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(responseString);

            token = json["access_token"].ToString();
        }
    }
}
