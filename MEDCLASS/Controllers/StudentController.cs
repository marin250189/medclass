using Business;
using MEDCLASS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace MEDCLASS.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        public ActionResult Index(StudentViewModel model)
        {
            return View(model);
        }

        //
        // GET: /Student/Details/5
        public ActionResult Details(int id)
        {
            Business.StudentBusiness _students = new StudentBusiness();
            Students entity = _students.GetById(id);
           
            return View(entity);
        }

        //
        // GET: /Student/Create
        public ActionResult Create()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public JsonResult List(jQueryDataTableParamModel param)
        {
            Business.StudentBusiness student = new Business.StudentBusiness();
            List<string[]> data = new List<string[]>();
            var studentList = student.GetAll();
            foreach (Domain.Students item in studentList)
            {
                data.Add(new string[] {item.Id+ string.Empty, item.firstName, item.lastName, item.age + string.Empty, item.gender, item.phoneNumber, "" });
            }            
           
            return Json(new
            {


                sEcho = param.sEcho,
                iTotalRecords = 10,
                iTotalDisplayRecords = 3,
                aaData = data
            },
        JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Student/Create
        [HttpPost]
        public ActionResult Create(StudentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Business.StudentBusiness student = new Business.StudentBusiness();
                    Domain.Students newStudent = new Domain.Students
                    {
                        firstName = model.firstName,
                        lastName = model.lastName,
                        age = model.age,
                        gender = model.gender,
                        phoneNumber = model.phoneNumber
                    };
                    student.Save(newStudent);
                }
                else
                {
                    foreach (var item in ModelState.AsQueryable().ToList())
                    {
                        if (item.Value.Errors.Count > 0)
                        {
                            ModelState.AddModelError("Error", item.Value.Errors.First().ErrorMessage + string.Empty);
                        }

                    }

                }

                return RedirectToAction("Index",model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(model);
            }
        }

        //
        // GET: /Student/Edit/5
        public ActionResult Edit(string Nombre,string Apellido, string Edad, string Genero, string Phone)
        {
            List<SelectListItem> genderList = new List<SelectListItem>();         
            genderList.Add(new SelectListItem { Text = "M",Value = "M", Selected = (Genero == "M")});
            genderList.Add(new SelectListItem { Text = "F", Value = "F", Selected = (Genero == "F") });
            ViewBag.Name = Nombre.Replace('%',' ');
            ViewBag.LastName = Apellido.Replace('%',' ');
            ViewBag.Age = Edad;
            ViewBag.Gender = genderList;
            ViewBag.Phone = Phone;
            

            return PartialView();  
        }

        //
        // POST: /Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Student/Delete/5
        [HttpPost]
        public JsonResult Delete(string id)
        {
            string Message = string.Empty;
            bool Error = false;
            try
            {                
                Business.StudentBusiness student = new Business.StudentBusiness();
                if (!String.IsNullOrEmpty(id)) 
                {
                    int identifier = int.Parse(id);
                    student.Delete(identifier);
                }                    
                else
                {
                    Error = true;
                    Message = "El Identificador del studiante no puede ser nulo";
                }
                
              
            }
            catch(Exception ex)
            {
                Message = ex.Message;
                Error = true;
            }
            return Json(new { Message= Message,Error= Error},JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Student/Delete/5
        [HttpPost]
        public JsonResult Update(string id, string name,string lastName, string gender, string age, string phone)
        {
            string Message = string.Empty;
            name = name.Replace('%', ' ');
            lastName = lastName.Replace('%', ' ');
            bool Error = false;
            try
            {
                Business.StudentBusiness student = new Business.StudentBusiness();
                if (!String.IsNullOrEmpty(id))
                {
                    int identifier = int.Parse(id);
                    Students entity = new Students
                    {
                        Id = identifier,
                        firstName = name,
                        lastName = lastName,
                        gender = gender,
                        age = int.Parse(age),
                        phoneNumber = phone
                    };
                    student.Update(entity);
                }
                else
                {
                    Error = true;
                    Message = "El Identificador del studiante no puede ser nulo";
                }


            }
            catch (Exception ex)
            {
                Message = ex.Message;
                Error = true;
            }
            return Json(new { Message = Message, Error = Error }, JsonRequestBehavior.AllowGet);
        }
    }
}
