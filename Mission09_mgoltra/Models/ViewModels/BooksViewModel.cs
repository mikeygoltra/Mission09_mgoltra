using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_mgoltra.Models.ViewModels
{

    //get the information about the number of books per page from PageInfo
    public class BooksViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
