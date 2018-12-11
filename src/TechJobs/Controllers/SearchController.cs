using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : TechJobs.Controllers
    {
        public IActionResult Index()
        {
            ViewBag.title = "Search";

            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results


        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<string, string>> foundJobs = new List<Dictionary<string, string>>();

            if (string.IsNullOrEmpty(searchType) || searchType == "all")
            {
                foundJobs = JobData.FindByValue(searchTerm);
            }
            else
            {
                foundJobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            ViewBag.title = "Search Results";
            ViewBag.jobs = foundJobs;
            ViewBag.searchTerm = searchTerm;
            ViewBag.searchType = searchType;

            return View("Index");
        }

    }
}
