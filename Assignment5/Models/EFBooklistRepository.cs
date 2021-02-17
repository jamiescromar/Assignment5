using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class EFBooklistRepository: iBooklistRepository
    {
        private BooklistDbContext _context;

        //constructor
        public EFBooklistRepository (BooklistDbContext context)
        {
            _context = context;
        }
        public IQueryable<Project> Projects => _context.Projects;
    }
}
