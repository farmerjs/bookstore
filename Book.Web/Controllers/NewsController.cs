using Book.Service.News;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Web.Controllers
{
    using Domain.News;
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        public IActionResult Index()
        {
            NewsItem newsItem = new NewsItem()
            {
                Full = "Detail text",
                SeName = "SeName",
                Short = "Short Name",
                Title = "Title Name",
                CreatedOnUtc = DateTime.Now
            };

            _newsService.InsertNews(newsItem);

            return View();
        }
    }
}
