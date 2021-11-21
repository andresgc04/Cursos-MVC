using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoMvc.Models.TablesViewsModels
{
    public class UserTableViewModel
    {
        public int Id_Usuario { get; set; }
        public string Email { get; set; }
        public int? Edad { get; set; }
    }
}