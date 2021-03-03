using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models.ViewModels
{
    public class ProjectListViewModel
    {
        //trying to print out all the information
        //build multiple things in here
        //WE get this information from the home controller
        public IEnumerable<Project> Projects { get; set; }
        //makes the html dynamic so that it ebs and flows
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
