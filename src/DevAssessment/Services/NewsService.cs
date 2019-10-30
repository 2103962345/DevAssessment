using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DevAssessment.DialogExtentions;
using DevAssessment.Models;
using Newtonsoft.Json;
using Polly;
using Prism.Services.Dialogs;

namespace DevAssessment.Services
{
    public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;

        private const string ApiNewsSourcesUrl = "https://newsapi.org/v2/sources?apiKey=f7cb4296dd7b4311b6c5e099345c71ab";

        public NewsService()
        {
            _httpClient = new HttpClient();
        }

            
        public async Task<LatestNews> GetLatestNews()
        {
            return await Policy
            .Handle<HttpRequestException>(ex => !ex.Message.ToLower().Contains("404"))
            .WaitAndRetryAsync
            (
                retryCount: 3,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(1),
                onRetry: (ex, time) =>
                {

                    Console.WriteLine($"Something went wrong: {ex.Message}, retrying...");
                }
            )
            .ExecuteAsync(async () =>
            {
                var uri = new Uri(ApiNewsSourcesUrl);

                var resultJson = await _httpClient.GetStringAsync(uri);

               return JsonConvert.DeserializeObject<LatestNews>(resultJson);

            });
           
        }

        public async Task<TopHeadlines> GetTopNewsByCategory(string country, string category, string apiKey)
        {
            return await Policy
            .Handle<HttpRequestException>(ex => !ex.Message.ToLower().Contains("404"))
            .WaitAndRetryAsync
            (
                retryCount: 3,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(1),
                onRetry: (ex, time) =>
                {

                    Console.WriteLine($"Something went wrong: {ex.Message}, retrying...");
                }
            )
            .ExecuteAsync(async () =>
            {
                string url = $"https://newsapi.org/v2/top-headlines?country={country}&category={category}&apiKey={apiKey}";

                var uri = new Uri(url);

                var resultJson = await _httpClient.GetStringAsync(uri);

                return JsonConvert.DeserializeObject<TopHeadlines>(resultJson);

            });
        }
    }
}
