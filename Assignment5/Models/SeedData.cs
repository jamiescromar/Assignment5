using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            BooklistDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BooklistDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Projects.Any())
            {
                context.Projects.AddRange(
                    new Project
                    {
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorMiddle = "",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95F,
                        Pages = 1488,
                    },
                    new Project
                    {
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris",
                        AuthorMiddle = "Kearns",
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58F,
                        Pages = 944,
                    },
                    new Project
                    {
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorMiddle = "",
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54F,
                        Pages = 832,
                    },
                    new Project
                    {
                        Title = "American Ulysses",
                        AuthorFirst = "Ronald",
                        AuthorMiddle = "C.",
                        AuthorLast = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61F,
                        Pages= 864,
                    },
                    new Project
                    {
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorMiddle = "",
                        AuthorLast = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33F,
                        Pages = 528,
                    },
                    new Project
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirst = "Michael",
                        AuthorMiddle = "",
                        AuthorLast = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95F,
                        Pages = 288,
                    },
                    new Project
                    {
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorMiddle = "",
                        AuthorLast = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99F,
                        Pages = 304,
                    },
                    new Project
                    {
                        Title = "It's Your Ship",
                        AuthorFirst = "Michael",
                        AuthorMiddle = "",
                        AuthorLast = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66F,
                        Pages = 240,
                    },
                    new Project
                    {
                        Title = "The Virgin Way",
                        AuthorFirst = "Richard",
                        AuthorMiddle = "",
                        AuthorLast = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16F,
                        Pages = 400,
                    },
                    new Project
                    {
                        Title = "Sycamore Row",
                        AuthorFirst = "John",
                        AuthorMiddle = "",
                        AuthorLast = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03F,
                        Pages = 642,
                    },
                    new Project
                    {
                        Title ="The Selection",
                        AuthorFirst = "Kiera",
                        AuthorMiddle = "",
                        AuthorLast = "Cass",
                        Publisher = "HarperCollins",
                        ISBN = "978-8868361136",
                        Classification = "Fantasy Fiction",
                        Category = "Thrillers",
                        Price = 9.95F,
                        Pages = 336,
                    },
                    new Project
                    {
                        Title = "Harry Potter",
                        AuthorFirst = "J.",
                        AuthorMiddle = "K.",
                        AuthorLast = "Rowling",
                        Publisher = "Scholastic Corporation",
                        ISBN = "978-0747532743",
                        Classification = "Fantasy",
                        Category = "Thrillers",
                        Price = 15.00F,
                        Pages = 223,
                    },
                    new Project
                    {
                        Title = "The Princess Academy",
                        AuthorFirst = "Shannon",
                        AuthorMiddle = "",
                        AuthorLast = "Hale",
                        Publisher = "Bloomsbury",
                        ISBN = "978-0398194743",
                        Classification = "Fantasy Fiction",
                        Category = "Novel",
                        Price = 15.00F,
                        Pages = 314,
                    }
                ) ;

                context.SaveChanges();
            }
        }
    }
}
