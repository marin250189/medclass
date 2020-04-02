using Domain;
using MEDCLASS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEDCLASS.Controllers
{
    public class SubjectController : Controller
    {
        //
        // GET: /Subject/
        public ActionResult Index()
        {
            List<SelectListItem> yearList = new List<SelectListItem>();
            yearList.Add(new SelectListItem { Text = "Primer", Value = "1" });
            yearList.Add(new SelectListItem { Text = "Segundo", Value = "2" });
            yearList.Add(new SelectListItem { Text = "Tercero", Value = "3" });
            yearList.Add(new SelectListItem { Text = "Cuarto", Value = "4" });
            yearList.Add(new SelectListItem { Text = "Quinto", Value = "5" });
            yearList.Add(new SelectListItem { Text = "Sexto", Value = "6" });
            ViewBag.YearList = yearList;
            return View();
        }

        public ActionResult AddStudents(string subjectId, string name)
        {

            ViewBag.Name = name.Replace('%', ' ');
            ViewBag.Id = subjectId;
            return View();
        }


        [HttpGet]
        public JsonResult List(jQueryDataTableParamModel param)
        {
            Business.SubjectBusiness subject = new Business.SubjectBusiness();
            List<string[]> data = new List<string[]>();
            var subjectList = subject.GetAll();
            foreach (Domain.Subject item in subjectList)
            {
                int students = item.Students != null ? item.Students.Count : 0;
                data.Add(new string[] { item.Id + string.Empty, item.Name, item.year + string.Empty, students + string.Empty, "" });
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

        [HttpGet]
        public JsonResult StudentAvaliable(jQueryDataTableParamModel param, string subjectId)
        {
            Business.SubjectBusiness subject = new Business.SubjectBusiness();
            Business.StudentBusiness student = new Business.StudentBusiness();
            List<Students> studentAvaliable = new List<Students>();
            List<Students> studentsAll = student.GetAll().ToList();
            var subjectList = subject.GetStudentsBySubject(subjectId);
            foreach (var item in studentsAll)
            {
                bool studentExist = subjectList.FirstOrDefault(a => a.Id == item.Id) != null;
                if (!studentExist)
                {
                    studentAvaliable.Add(item);
                }
            }


            List<string[]> data = new List<string[]>();

            foreach (Domain.Students item in studentAvaliable)
            {
                //int students = item.Students != null ? item.Students.Count : 0;
                data.Add(new string[] { item.Id + string.Empty, item.firstName, item.lastName + string.Empty, item.gender, item.age + string.Empty, item.phoneNumber });
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

        [HttpGet]
        public JsonResult StudentList(jQueryDataTableParamModel param, string subjectId)
        {
            Business.SubjectBusiness subject = new Business.SubjectBusiness();
            List<string[]> data = new List<string[]>();
            var subjectList = subject.GetStudentsBySubject(subjectId);
            foreach (Domain.Students item in subjectList)
            {
                //int students = item.Students != null ? item.Students.Count : 0;
                data.Add(new string[] { item.Id + string.Empty, item.firstName, item.lastName + string.Empty, item.gender, item.age + string.Empty, item.phoneNumber });
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
        // GET: /Subject/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Subject
        [HttpPost]
        public ActionResult Create(SubjectViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Business.SubjectBusiness subject = new Business.SubjectBusiness();
                    Domain.Subject newSubject = new Domain.Subject
                    {
                        Name = model.Name,
                        year = model.Year,
                        

                    };
                    subject.Save(newSubject);

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

                return RedirectToAction("Index", model);

            }
            catch (Exception ex)
            {

                //Code to save the customer data here
                ViewData["error"] = ex.Message;
                return RedirectToAction("Index", model);
            }

        }



        //
        // GET: /Subject/Edit/5
        public ActionResult Edit(string Name, string Year)
        {
            List<SelectListItem> yearList = new List<SelectListItem>();
            yearList.Add(new SelectListItem { Text = "Primer", Value = "1", Selected = (Year == "1") });
            yearList.Add(new SelectListItem { Text = "Segundo", Value = "2", Selected = (Year == "2") });
            yearList.Add(new SelectListItem { Text = "Tercero", Value = "3", Selected = (Year == "3") });
            yearList.Add(new SelectListItem { Text = "Cuarto", Value = "4", Selected = (Year == "4") });
            yearList.Add(new SelectListItem { Text = "Quinto", Value = "5", Selected = (Year == "5") });
            yearList.Add(new SelectListItem { Text = "Sexto", Value = "6", Selected = (Year == "6") });
            ViewBag.Name = Name.Replace('%', ' ');

            ViewBag.YearList = yearList;


            return PartialView();
        }

        //
        // POST: /Subject/Edit/5
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
        // GET: /Subject/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }




        [HttpPost]
        public JsonResult DeleteStudentToSubject(string[] students, string subjectId)
        {
            string Message = string.Empty;
            bool Error = false;
            try
            {
                if (students != null && subjectId != null)
                {
                    //string[] studentsList = students.Split(',');

                    Business.SubjectBusiness subject = new Business.SubjectBusiness();
                    int[] studentId = new int[students.Length];
                    for (int i = 0; i < students.Length; i++)
                    {
                        studentId[i] = int.Parse(students[i]);
                       
                    }
                   Error = subject.DeleteStudent(studentId, int.Parse(subjectId)) == false;
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
                Error = true;
            }

            return Json(new { Message = Message, Error = Error }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddStudentToSubject(string[] students, string subjectId)
        {
            string Message = string.Empty;
            bool Error = false;
            try
            {
                if (students != null && subjectId != null)
                {
                    //string[] studentsList = students.Split(',');

                    Business.SubjectBusiness subject = new Business.SubjectBusiness();
                    int[] studentId = new int[students.Length];
                    for (int i = 0; i < students.Length; i++)
                    {
                        studentId[i] = int.Parse(students[i]);
                       
                    }
                    subject.AddStudent(studentId, int.Parse(subjectId));
                    
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
                Error = true;
            }

            return Json(new { Message = Message, Error = Error }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            string Message = string.Empty;
            bool Error = false;
            try
            {
                Business.SubjectBusiness subject = new Business.SubjectBusiness();
                if (!String.IsNullOrEmpty(id))
                {
                    int identifier = int.Parse(id);
                    subject.Delete(identifier);
                }
                else
                {
                    Error = true;
                    Message = "El Identificador de la asginatura no puede ser nulo";
                }


            }
            catch (Exception ex)
            {
                Message = ex.Message;
                Error = true;
            }
            return Json(new { Message = Message, Error = Error }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(string id, string name, string year)
        {
            string Message = string.Empty;
            bool Error = false;
            try
            {
                Business.SubjectBusiness subject = new Business.SubjectBusiness();
                if (!String.IsNullOrEmpty(id))
                {
                    int identifier = int.Parse(id);
                    Subject entity = new Subject
                    {
                        Id = identifier,
                        Name = name,
                        year = int.Parse(year)
                    };
                    subject.Update(entity);
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
