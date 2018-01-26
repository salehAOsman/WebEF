using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpGet]
        public ActionResult Index()
        {
            // add here list as storage we tell data base for look at people table then and find info- then convert found things to list  
            List<Person> mylist = db.People.ToList();
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
            db.People.Add(me);//add bobbo to DB

            db.SaveChanges();//saves the changes (add bobbo) may be we need to add many new informations then we do this code as "db.SaveChanges()"
            // then we redirect to action "index" 
            return RedirectToAction("Index");
        }

        //it is important to build details Cars for each person
        //we create this method for details actionLink  method that relates to display Cars details for each person
        // GET: Cars/Details/5
        //efter we create this Get method then we will create view that need to select  from template "Details tremplate " thren
        //then Cars class then my data base 
        public ActionResult Details(int? id)
        {
            //when we use ? then can this be null then we have to check with if it is null then do thing or not as down
            //this input id is person id
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //and we will change to another collection code for details car
            
            //Person person = db.People.Find(id);
            
            //this key word include name of reference list "Cars" and we use lamda to search inside list by loop

            Person person = db.People.Include("Cars").SingleOrDefault(p => p.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }
        [HttpGet]
        // we add here new method to add new cars for a person and we need id of person to know how is that person to add to hem this special car 
        public  ActionResult AddCarToPerson(int pId)
        {
            // we need to seach inside car list then we need object from car list
            List<Car> cars = db.Cars.ToList();

            //we need to send id of person
            //then we need to add view it is template list of Cars then add view
            ViewBag.pId = pId;
            return View(cars);
        }
        //we need to add this method to specifiy this car to that person 
        [HttpGet]
        public ActionResult CarToPerson(int cId,int pId)
        {
            // we need to seach inside car list then we need object from car list
            // we have id for car then we need just find to look at one car not all list to check and get object of here by lamda 

            Car car = db.Cars.SingleOrDefault(c=>c.Id==cId);
            // and the same for person by his list 
            // we have to add "Include("Cars")" because if person table relates with another table then we need to refere to this table to fetch every cars that he has it because we need to know those cars that he hade before 
            Person person = db.People.Include("Cars").SingleOrDefault(p => p.Id == pId);
            // now we will add this car to that personCar table that EF created by salf
            person.Cars.Add(car);

            // we need now to add to Database
            db.SaveChanges();
            //we need to send id of person
            //then we need to add view it is template list of Cars then add view
            ViewBag.pId = pId;
            //we go back to details direct we do not view here just go back
            return RedirectToAction("Details",new {id=pId });
        }
    }
}