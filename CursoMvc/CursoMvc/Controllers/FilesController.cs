using CursoMvc.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMvc.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            if (TempData["Message"] != null)
                ViewBag.Message = TempData["Message"].ToString();


            return View();
        }

        [HttpPost]
        public ActionResult Save(FileViewModel model)
        {
            string PathSite = Server.MapPath("~/");
            string PathFile1 = Path.Combine(PathSite + "/Files/file1.png");
            string PathFile2 = Path.Combine(PathSite + "/Files/file2.png");

            if (!ModelState.IsValid)
                return View("Index", model);

            model.File1.SaveAs(PathFile1);
            model.File2.SaveAs(PathFile2);

            @TempData["Message"] = "Se cargaron los archivos";

            return RedirectToAction("Index");
        }
    }
}