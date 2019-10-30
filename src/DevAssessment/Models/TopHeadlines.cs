using System;
using System.Collections.Generic;
using System.Text;

namespace DevAssessment.Models
{
    public class TopHeadlines
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }
    }

   
}
