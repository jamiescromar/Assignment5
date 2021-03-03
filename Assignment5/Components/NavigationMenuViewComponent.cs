using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private iBooklistRepository repository;

        public NavigationMenuViewComponent (iBooklistRepository r)
        {
            repository = r;
        }
        public IViewComponentResult Invoke()
        {
            //dynamically highlight the category that is selected
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Projects
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
