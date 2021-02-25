using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models.ViewModels
{
    //This is showing us all of the paging info so that we can store this to this class and call it later
    public class PagingInfo
    {
        //attribute totlay num items if the total number of books
        public int TotalNumItems { get; set; }

        //this will get how many books we want per page
        public int ItemsPerPage { get; set; }
        //this will get how many books are one the current page so that it is adynamic website
        public int CurrentPage { get; set; }
        //This will shwo us the total number of pages so we can create the navigation between the pages.
        public int TotalPages => (int)(Math.Ceiling((decimal)TotalNumItems / ItemsPerPage));
    }
}
