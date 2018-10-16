using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        PhoneBookEntities db = new PhoneBookEntities();
        public ActionResult Index()
        {
            
            ViewBag.TotalPersons = 0;
            DateTime stratdate = DateTime.Now;
            DateTime Dateaftertendays = stratdate.AddDays(10);
            List<Person> list = db.People.ToList();
            List<PersonViewModel> viewList = new List<PersonViewModel>();
            List<PersonViewModel> viewList2 = new List<PersonViewModel>();
            foreach (Person s in list)
            {
                if (s.AddedBy == User.Identity.GetUserId())
                {
                    DateTime DateofBirth = s.DateOfBirth??DateTime.Now;
                    ViewBag.TotalPersons = ViewBag.TotalPersons + 1;
                    if ((stratdate.Day< DateofBirth.Day   && DateofBirth.Day < Dateaftertendays.Day) &&(DateofBirth.Month == stratdate.Month && DateofBirth.Month == Dateaftertendays.Month))
                    {
                        PersonViewModel obj = new PersonViewModel();
                        obj.PersonId = s.PersonId;
                        obj.FirstName = s.FirstName;
                        obj.MiddleName = s.MiddleName;
                        obj.LastName = s.LastName;
                        obj.DateOfBirth = s.DateOfBirth;
                        obj.AddedOn = s.AddedOn;
                        obj.AddedBy = s.AddedBy;
                        obj.HomeAddress = s.HomeAddress;
                        obj.HomeCity = s.HomeCity;
                        obj.FaceBookAccountId = s.FaceBookAccountId;
                        obj.LinkedInId = s.LinkedInId;
                        obj.UpdateOn = s.UpdateOn;
                        obj.TwitterId = s.TwitterId;
                        obj.EmailId = s.EmailId;
                        viewList.Add(obj);
                    }
                    DateTime DateBeforeSevenDays = DateTime.Now.AddDays(-7);
                    DateTime TodayDate = DateTime.Now;
                    if(s.UpdateOn < TodayDate && s.UpdateOn > DateBeforeSevenDays)
                    {
                        PersonViewModel obj = new PersonViewModel();
                        obj.PersonId = s.PersonId;
                        obj.FirstName = s.FirstName;
                        obj.MiddleName = s.MiddleName;
                        obj.LastName = s.LastName;
                        obj.DateOfBirth = s.DateOfBirth;
                        obj.AddedOn = s.AddedOn;
                        obj.AddedBy = s.AddedBy;
                        obj.HomeAddress = s.HomeAddress;
                        obj.HomeCity = s.HomeCity;
                        obj.FaceBookAccountId = s.FaceBookAccountId;
                        obj.LinkedInId = s.LinkedInId;
                        obj.UpdateOn = s.UpdateOn;
                        obj.TwitterId = s.TwitterId;
                        obj.EmailId = s.EmailId;
                        viewList2.Add(obj);
                    }
                    
                }
               

            }
            var UB = new UpdateBirthdayViewModel
            {
                UpdatePerson = viewList,
                Person = viewList
            };

            return View(viewList2);
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}