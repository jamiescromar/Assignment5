using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    //This is meant to be inherited from. This will define the structure. Base class
    public interface iBooklistRepository
    {
        //only allow a get so that we can pull data
        IQueryable<Project> Projects { get; }
    }
}
