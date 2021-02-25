using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    //This is the class that will get the data for each book that will be stored to the database
    public class Project
    {
        //Set the key for this class and for the database
        [Key]
        [Required]
        //Make sure that all of the data is required and that it is going to be entered when pushing data to the database
        //Any changes here can be pushed using migrations
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirst { get; set; }
        [Required]
        public string? AuthorMiddle { get; set; }
        [Required]
        public string AuthorLast { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{10}$", ErrorMessage = "Invalid input for ISBN")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Pages { get; set; }
    }
}
