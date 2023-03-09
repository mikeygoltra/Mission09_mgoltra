using Microsoft.AspNetCore.Mvc;
using Mission09_mgoltra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_mgoltra.Components
{
    public class CategoriesViewComponent : ViewComponent
    { 
        private IBookstoreRepository repo { get; set; }

        public CategoriesViewComponent(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];


            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }

    }
}
