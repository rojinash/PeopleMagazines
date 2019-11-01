using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManyToMany.Models;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Magazines()
        {
            List<Magazine> AllMagazines = dbContext.Magazines.ToList();
            ViewBag.magazines = AllMagazines;
            return View();
        }

        [HttpGet]
        [Route("magazines/{magazineId}")]
        public IActionResult Magazine(int magazineId)
        {
            Magazine magazine = dbContext.Magazines.Include(u => u.Readers)
            .ThenInclude(c => c.Person)
            .FirstOrDefault(u => u.MagazineId == magazineId);
            ViewBag.magazine = magazine;
            List<Person> AllPeople = dbContext.People.ToList();
            List<Person> usedPeople = new List<Person>();
            foreach(Subscription subscription in magazine.Readers) {
                usedPeople.Add(subscription.Person);
            }
            var newPeople = AllPeople.Except(usedPeople);
            ViewBag.people = newPeople;
            return View();
        }

        [HttpGet]
        [Route("people")]
        public IActionResult People()
        {
            List<Person> AllPeople = dbContext.People.ToList();
            ViewBag.people = AllPeople;
            return View();
        }
        
        [HttpGet]
        [Route("people/{personId}")]
        public IActionResult Person(int personId)
        {
            Person person = dbContext.People.Include(p => p.Subscriptions)
            .ThenInclude(s => s.Magazine)
            .FirstOrDefault(p=> p.PersonId == personId);
            ViewBag.person = person;
            List<Magazine> AllMagazines = dbContext.Magazines.ToList();
            List<Magazine> usedMagazines = new List<Magazine>();
            foreach(Subscription sub in person.Subscriptions) {
                usedMagazines.Add(sub.Magazine);
            }
            var newMagazine = AllMagazines.Except(usedMagazines);
            ViewBag.magazines = newMagazine;
            return View();
        }

        [HttpPost]
        [Route("magazine/new")] 
        public IActionResult CreateMagazine(Magazine newMagazine) {
            if(ModelState.IsValid){
                dbContext.Add(newMagazine);
                dbContext.SaveChanges();
                return RedirectToAction("Magazines");
            }
            List<Magazine> AllMagazines = dbContext.Magazines.ToList();
            ViewBag.magazines = AllMagazines;
            return View("Magazines");
        }

        [HttpPost]
        [Route("person/new")] 
        public IActionResult CreatePerson(Person newPerson) {
            if(ModelState.IsValid){
                dbContext.Add(newPerson);
                dbContext.SaveChanges();
                return RedirectToAction("People");
            }
            List<Person> AllPeople = dbContext.People.ToList();
            ViewBag.people = AllPeople;
            return View("People");
        }

        [HttpPost]
        [Route("add/magazine")] 
        public IActionResult AddMagazine(Subscription newSubscription) {
            dbContext.Add(newSubscription);
            dbContext.SaveChanges();
            return RedirectToAction("Person", new {personId = newSubscription.PersonId});
        }

        [HttpPost]
        [Route("add/person")] 
        public IActionResult AddPerson(Subscription newSubscription) {
            dbContext.Add(newSubscription);
            dbContext.SaveChanges();
            return RedirectToAction("Magazine", new{magazineId = newSubscription.MagazineId});
        }


        
    }
}
