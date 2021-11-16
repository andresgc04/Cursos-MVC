using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMvc.Models;

namespace CursoMvc.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string email, string password)
        {
            try
            {
                using (CursosDbEntities db = new CursosDbEntities())
                {
                    var lst = from d in db.Usuarios where d.Email == email && d.Password == password && d.Id_Estado == 1 select d;

                    if (lst.Count() > 0)
                    {
                        Session["User"] = lst.First();
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario invalido :C");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error inesperado :C " + ex.Message);
            }
        }
    }
}