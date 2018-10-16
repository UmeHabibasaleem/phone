using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {
        PhoneBookEntities db = new PhoneBookEntities();
        // GET: Person
        public ActionResult Index()
        {


            List<Person> list = db.People.ToList();
            List<PersonViewModel> viewList = new List<PersonViewModel>();
            foreach (Person s in list)
            {
                if (s.AddedBy == User.Identity.GetUserId())
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

            }
            return View(viewList);

        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            PersonViewModel obj = new PersonViewModel();
            Person s = db.People.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            else
            {
                obj.PersonId = s.PersonId;
                obj.FirstName = s.FirstName;
                obj.MiddleName = s.MiddleName;
                obj.LastName = s.LastName;
                obj.DateOfBirth = s.DateOfBirth;
                obj.AddedOn = DateTime.Now;
                obj.AddedBy = s.AddedBy;
                obj.HomeAddress = s.HomeAddress;
                obj.HomeCity = s.HomeCity;
                obj.FaceBookAccountId = s.FaceBookAccountId;
                obj.LinkedInId = s.LinkedInId;
                obj.UpdateOn = s.UpdateOn;
                obj.TwitterId = s.TwitterId;
                obj.EmailId = s.EmailId;
            }
            return View(obj);
           
        }

        // GET: Person/Create
        public ActionResult Create()
        {
             return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonViewModel obj)
        {

            try
            {
                // TODO: Add insert logic here

                Person s = new Person();
                // s.PersonId = s.PersonId;
                s.FirstName = obj.FirstName;
                s.MiddleName = obj.MiddleName;
                s.LastName = obj.LastName;
                s.DateOfBirth = obj.DateOfBirth;
                s.AddedOn = DateTime.Now;
                // s.AddedBy = obj.AddedBy;
                s.HomeAddress = obj.HomeAddress;
                s.HomeCity = obj.HomeCity;
                s.FaceBookAccountId = obj.FaceBookAccountId;
                s.LinkedInId = obj.LinkedInId;
                s.UpdateOn = obj.UpdateOn;
                s.ImagePath = obj.ImagePath;
                s.TwitterId = obj.TwitterId;
                s.EmailId = obj.EmailId;
                s.AddedBy = User.Identity.GetUserId();
                db.People.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            PersonViewModel obj = new PersonViewModel();
            Person s = db.People.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            else
            {

                obj.PersonId = s.PersonId;
                obj.FirstName = s.FirstName;
                obj.MiddleName = s.MiddleName;
                obj.LastName = s.LastName;
                obj.DateOfBirth = s.DateOfBirth;
                obj.AddedOn = DateTime.Now;
                obj.AddedBy = s.AddedBy;
                obj.HomeAddress = s.HomeAddress;
                obj.HomeCity = s.HomeCity;
                obj.FaceBookAccountId = s.FaceBookAccountId;
                obj.LinkedInId = s.LinkedInId;
                obj.UpdateOn = s.UpdateOn;
                obj.TwitterId = s.TwitterId;
                obj.EmailId = s.EmailId;

            }
            return View(obj);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonViewModel obj)
        {
            try
            {
                // TODO: Add insert logic here
                PhoneBookEntities ent = new PhoneBookEntities();
                db.People.Find(id).FirstName = obj.FirstName;
                db.People.Find(id).LastName = obj.LastName;
                db.People.Find(id).MiddleName = obj.MiddleName;
                db.People.Find(id).PersonId = obj.PersonId;
                db.People.Find(id).HomeCity = obj.HomeCity;
                db.People.Find(id).HomeAddress = obj.HomeAddress;
                db.People.Find(id).ImagePath = obj.ImagePath;
                db.People.Find(id).FaceBookAccountId = obj.FaceBookAccountId;
                db.People.Find(id).DateOfBirth = obj.DateOfBirth;
                db.People.Find(id).EmailId = obj.EmailId;
                db.People.Find(id).TwitterId = obj.TwitterId;
                db.People.Find(id).UpdateOn = obj.UpdateOn;
                db.People.Find(id).LinkedInId = obj.LinkedInId;
                db.People.Find(id).AddedBy = obj.AddedBy;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            PersonViewModel obj = new PersonViewModel();
            Person s = db.People.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            else
            {

                obj.PersonId = s.PersonId;
                obj.FirstName = s.FirstName;
                obj.MiddleName = s.MiddleName;
                obj.LastName = s.LastName;
                obj.DateOfBirth = s.DateOfBirth;
                obj.AddedOn= DateTime.Now;
                obj.AddedBy = s.AddedBy;
                obj.HomeAddress = s.HomeAddress;
                obj.HomeCity = s.HomeCity;
                obj.FaceBookAccountId = s.FaceBookAccountId;
                obj.LinkedInId = s.LinkedInId;
                obj.UpdateOn = s.UpdateOn;
                obj.TwitterId = s.TwitterId;
                obj.EmailId = s.EmailId;

            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult Delete(int id, PersonViewModel obj)
        {
            try
            {
                // TODO: Add insert logic here
                
                var v = db.People.Where(a => a.PersonId == id).First();
                db.Entry(v).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
       
    }
}

