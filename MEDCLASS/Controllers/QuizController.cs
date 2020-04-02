using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEDCLASS.Controllers
{
    public class QuizController : Controller
    {
        //
        // GET: /Quiz/
        public ActionResult Index()
        {
            Business.SubjectBusiness subject = new Business.SubjectBusiness();
            try
            {
                List<Subject> subjectList = subject.GetAll().ToList();
                List<SelectListItem> yearList = new List<SelectListItem>();
                foreach (var item in subjectList)
                {
                    
                }
               
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error", ex);
            }
            return View();
        }
	}
}