using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        PhoneBookEntities db = new PhoneBookEntities();
        
        // GET: Contact
       // int Personid;
        public ActionResult Index(int id )
        {
            List<Contact> list = db.Contacts.ToList();
            List<ContactViewModel> viewList = new List<ContactViewModel>();
            foreach (Contact s in list)
            {
                if (s.PersonId == id)
                {
                    ContactViewModel obj = new ContactViewModel();
                    obj.PersonId = s.PersonId;
                    obj.ContactNumber = s.ContactNumber;
                    obj.ContactId = s.ContactId;
                    obj.Type = s.Type;
                    viewList.Add(obj);
                }

            }
            ViewBag.personId = id;
            return View(viewList);
         }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            ContactViewModel obj = new ContactViewModel();
            Contact s = db.Contacts.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            else
            {
                obj.ContactNumber = s.ContactNumber;
                obj.ContactId = s.ContactId;
                obj.Type = s.Type;
                obj.PersonId = s.PersonId;

            }
            return View(obj);
        }

        // GET: Contact/Create
        public ActionResult Create(int id)
        {

            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(int id,ContactViewModel obj)
        {
            try
            {
                // TODO: Add insert logic here

                Contact contact = new Contact();
                contact.ContactNumber = obj.ContactNumber;
                contact.ContactId = obj.ContactId;
                contact.Type = obj.Type;
                contact.PersonId = id;
                db.Contacts.Add(contact);
                db.SaveChanges();
               // Personid = id;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            ContactViewModel obj = new ContactViewModel();
            Contact s = db.Contacts.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            else
            {
               obj.ContactNumber = s.ContactNumber;
                obj.ContactId = s.ContactId;
                obj.Type = s.Type;
                obj.PersonId = s.PersonId;

            }
            return View(obj);
           
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ContactViewModel obj)
        {
            try
            {
                // TODO: Add update logic here
                db.Contacts.Find(id).ContactNumber = obj.ContactNumber;
                db.Contacts.Find(id).Type = obj.Type;
                db.Contacts.Find(id).PersonId = obj.PersonId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            ContactViewModel obj = new ContactViewModel();
            Contact s = db.Contacts.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            else
            {
                obj.ContactNumber = s.ContactNumber;
                obj.ContactId = s.ContactId;
                obj.Type = s.Type;
                obj.PersonId = s.PersonId;
            }
            return View(obj);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ContactViewModel obj)
        {
            try
            {
                // TODO: Add insert logic here

                var v = db.Contacts.Where(a => a.ContactId == id).First();
                db.Entry(v).State = System.Data.Entity.EntityState.Deleted;
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
