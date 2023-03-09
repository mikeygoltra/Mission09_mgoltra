﻿using Microsoft.AspNetCore.Mvc;
using Mission09_mgoltra.Models;
using Mission09_mgoltra.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_mgoltra.Controllers
{
    public class HomeController : Controller
    {

        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }
        private BookstoreContext context { get; set; }

        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                   .Where(b => b.Category == bookCategory || bookCategory == null)
                   .OrderBy(b => b.Title)
                   .Skip((pageNum - 1) * pageSize)
                   .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookCategory == null
                                        ? repo.Books.Count()
                                        : repo.Books.Where(x=> x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
