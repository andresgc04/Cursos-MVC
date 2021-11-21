using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMvc.Models;
using CursoMvc.Models.TablesViewsModels;
using CursoMvc.Models.ViewsModels;

namespace CursoMvc.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;

            using (CursosDbEntities db = new CursosDbEntities())
            {
                lst = (from d in db.Usuarios
                       where d.Id_Estado == 1
                       orderby d.Email
                       select new UserTableViewModel
                       {
                           Id_Usuario = d.Id_Usuario,
                           Email = d.Email,
                           Edad = d.Edad
                       }).ToList();
            }


            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (var db = new CursosDbEntities())
            {
                Usuarios usuariosObj = new Usuarios();
                usuariosObj.Id_Estado = 1;
                usuariosObj.Email = model.Email;
                usuariosObj.Edad = model.Edad;
                usuariosObj.Password = model.Password;

                db.Usuarios.Add(usuariosObj);

                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }
    }
}