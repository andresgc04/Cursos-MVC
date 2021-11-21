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

        public ActionResult Edit(int Id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new CursosDbEntities())
            {
                var usuarioObj = db.Usuarios.Find(Id);
                model.Edad = (int)usuarioObj.Edad;
                model.Email = usuarioObj.Email;
                model.Id_Usuario = usuarioObj.Id_Usuario;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (var db = new CursosDbEntities())
            {
                var usuarioObj = db.Usuarios.Find(model.Id_Usuario);
                usuarioObj.Email = model.Email;
                usuarioObj.Edad = model.Edad;

                if (model.Password != null && model.Password.Trim() != "")
                    usuarioObj.Password = model.Password;

                db.Entry(usuarioObj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new CursosDbEntities())
            {
                var usuarioObj = db.Usuarios.Find(Id);
                usuarioObj.Id_Estado = 3; //Eliminar

                db.Entry(usuarioObj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }
    }
}