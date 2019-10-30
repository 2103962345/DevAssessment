using DevAssessment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevAssessment.Services
{
    public interface INewsService
    {
        Task<LatestNews> GetLatestNews();

        Task<TopHeadlines> GetTopNewsByCategory(string country, string category, string apiKey);
    }
}
