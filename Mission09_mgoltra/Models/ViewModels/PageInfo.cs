using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_mgoltra.Models.ViewModels
{
    public class PageInfo
    {

        //determine all the numeric info about the pages
        public int TotalNumBooks { get; set; }

        public int BooksPerPage { get; set; }

        public int CurrentPage { get; set; }

        //Figure out how many pages are needed
        public int TotalPages => ((int) Math.Ceiling((double) TotalNumBooks / BooksPerPage));
    }
}
