using LolStats742.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolStats742
{
    internal interface IRiotClient
    {
        //users
        Task<SummonerDTO> GetSummonerByPuuIdAsync(string puuid,
            CancellationToken token = default);
        Task<SummonerDTO> GetSummonerByNameAsync(string name,     
            CancellationToken token = default);


        //matches
        Task<List<string>> GetMatchesByUserIdAsync(string userId,
            long? startTime = null,
            long? endTime = null,
            int? queue = null,
            string? type = null,
            int start = 0,
            int count = 100,
            CancellationToken token = default);

        Task<MatchDTO> GetMatchByMatchIdAsync(string matchId,
            CancellationToken token = default);

    }


    internal class RiotClient : IRiotClient
    {
        private readonly IConfiguration _configuration;

        private readonly HttpClient _httpClient;
        
        public RiotClient(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<SummonerDTO> GetSummonerByPuuIdAsync(string puuid, CancellationToken token = default)
        {
            return await GetAsync<SummonerDTO>("euw1", $"summoner/v4/summoners/by-puuid/{puuid}");
        }

        public async Task<SummonerDTO> GetSummonerByNameAsync(string name, CancellationToken token = default)
        {
            return await GetAsync<SummonerDTO>("euw1", $"summoner/v4/summoners/by-name/{name}");
        }

        public async Task<List<string>> GetMatchesByUserIdAsync(
            string userId,
            long? startTime = null,
            long? endTime = null,
            int? queue = null,
            string? type = null,
            int start = 0,
            int count = 100, 
            CancellationToken token = default)
        {
            var queryParameters = new Dictionary<string, object>();
            if (startTime != null)
                queryParameters["startTime"] = startTime;
            if (endTime != null)
                queryParameters["endTime"] = endTime;
            if (queue != null)
                queryParameters["queue"] = queue;
            if (type != null)
                queryParameters["type"] = type;

            queryParameters["start"] = start;
            queryParameters["count"] = count;

            return await GetAsync<List<string>>("europe", $"match/v5/matches/by-puuid/{userId}/ids", queryParameters);
        }

        public async Task<MatchDTO> GetMatchByMatchIdAsync(string matchId, CancellationToken token = default)
        {
            return await GetAsync<MatchDTO>("europe", $"match/v5/matches/{matchId}");
        }

        private  async Task<T> GetAsync<T>(string region, string resource, IDictionary<string, object>? queryParameters = null, CancellationToken token = default(CancellationToken))
        {
            var url = $"https://{region}.api.riotgames.com/lol/{resource}";

            if (queryParameters != null)
            url = AppendQuerryParams(url, queryParameters);

            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            msg.Headers.Add("X-Riot-Token", _configuration.GetValue<string>("ApiKey"));
            var res = await _httpClient.SendAsync(msg);

            var result = await SerializeAsAsync<T>(res.Content);

            return result;
        }

        private string AppendQuerryParams(string url, IDictionary<string, object> queryParameters)
        {
            url = url.EndsWith('?') ? url : url + "?";

            string linearQuery = string.Join("&", queryParameters.Select(elem => elem.Key + "=" + elem.Value));

            return url + linearQuery;
        }

        private async Task<T> SerializeAsAsync<T>(HttpContent content)
        {

            var contString = content.ReadAsStringAsync();
            var serializer = JsonSerializer.Create();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (var stream = await content.ReadAsStreamAsync().ConfigureAwait(false))
            using (var reader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
