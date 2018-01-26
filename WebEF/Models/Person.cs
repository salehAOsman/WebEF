using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEF.Models
{
    //1 we start for EF with new empty mvc project then install EF from "manage NuGet" then create new 
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        // 1 --> *
        public List<Car> Cars { get; set; }

    }
}