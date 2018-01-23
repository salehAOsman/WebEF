using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEF.Models;

namespace WebEF.Controllers
{
    public class HomeController : Controller
    {
        //efter we install EF and sql server we make this controller
        //We add here new object t o handle to connect to data base 
        // GET: Home
        // we need here t oadd ctr . "using WebEF.Models;"to avoid red line 
        PeopleDbContext db = new PeopleDbContext();

        public ActionResult Index()
        {
            // add here list as storage we tell data base for look at people table then and find info- then convert found things to list  
            List<Person> mylist = db.people.ToList();
            // then we will create view but we need to do Build solution for first time 
            // we need to select list from template and name of model and name of data bass
            //here send obj the view  
            return View(mylist);
        }
        
        public ActionResult Create()
        {
            Person me = new Person();

            me.Name = "Bobbo";
            me.Age = 99;
            // we need to retern this info to data base by this code we have obj for dbase and name of table 
            db.people.Add(me);//add bobbo to DB

            db.SaveChanges();//saves the changes (add bobbo) may be we need to add many new informations then we do this code as "db.SaveChanges()"
            // then we redirect to action "index" 
            return RedirectToAction("Index");
        }


    }
}