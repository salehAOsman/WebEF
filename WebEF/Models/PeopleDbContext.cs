using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebEF.Models
{
    //efter we install EF then we add this model 
    // it need to add using "using System.Data.Entity;" to right 
    //we create this class
    public class PeopleDbContext: DbContext
    {
        // we create link name to data base here efter :base this name "PeopleDbContext" is reference to the data base
        public PeopleDbContext() : base("name=PeopleDbContext")
        {
        }
        // we need thing  to till wich will senqronise with data base 
        // the data that will flow is type of class People with key DbSet one person per a row 
        public DbSet<Person> people { get; set; }
        // we go to "webconfig" in the root it is last file in project efter the line number 16 as default 

    }
}