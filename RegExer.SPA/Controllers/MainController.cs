using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace RegExer.SPA.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult DoRegex(string source, string search, string replace)
        {
            var ueSource = Uri.UnescapeDataString(source);
            var ueSearch = Uri.UnescapeDataString(search);
            var ueReplace = Uri.UnescapeDataString(replace);

            string result = null;
            string comment = null;
            bool success = false;

            try
            {
                result = Regex.Replace(ueSource, ueSearch, ueReplace);
                success = true;
                comment = "Ok";
            }
            catch (Exception ex)
            {
                success = false;
                comment = ex.Message;
            }

            return Json(new { result, comment, success }, JsonRequestBehavior.AllowGet);
        }
    }
}