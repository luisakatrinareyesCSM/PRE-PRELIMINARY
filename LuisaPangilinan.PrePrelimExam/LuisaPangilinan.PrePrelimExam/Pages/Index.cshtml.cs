using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;

namespace LuisaPangilinan.PrePrelimExam.Pages
{

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public NewsData? Data { get; set; }
        public async Task<IActionResult> OnGet()

        {
            var client = new RestClient("https://saurav.tech/NewsAPI/top-headlines/category/health/in.json");

            var request = new RestRequest("", Method.Get);

            RestResponse response = client.Execute(request);

            var content = response.Content;

            var area = JsonConvert.DeserializeObject<NewsDetails>(content);
            return Page();
        }
        public class NewsData
        {
            public NewsDetails? Details { get; set; }
            public NewsMain? Main { get; set; }
        }
        public class NewsDetails
        {
            public string? title { get; set; }
            public string? author { get; set; }
            public string? url { get; set; }
            public string? decription { get; set; }
        }
        public class NewsMain
        {
            public string? Image { get; set; }
            public string? Content { get; set; }
        }

    }
}