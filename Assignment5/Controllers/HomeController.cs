using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment5.Models.ViewModels;

namespace Assignment5.Controllers
{
    public class HomeController : Controller
    {
        //Creating variable so that we can have a dynamic web page so that we can view this information and the program will automtically decide the length.
        private readonly ILogger<HomeController> _logger;

        private iBooklistRepository _repository;

        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, iBooklistRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            //populates the information so that it will be dynamic
            return View(new ProjectListViewModel
            {
                //This is just like SQL and making it so that we are querying the information based on its length
                Projects = _repository.Projects
                //if category is null or somebody has pased in something for category they will assign that
                .Where(p => category == null || p.Category == category )
                .OrderBy(p => p.BookID)
                .Skip((pageNum - 1) * PageSize)
                .Take(PageSize)
                ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    //THis will make sure that the pages are correct if you are filtering by category
                    TotalNumItems =category == null ? _repository.Projects.Count(): 
                    _repository.Projects.Where(x => x.Category == category).Count()
                },
                //Get the current category that has been selected
                CurrentCategory = category
            }); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
