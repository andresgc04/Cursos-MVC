using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoMvc.Models.ViewsModels
{
    public class FileViewModel
    {
        [Required]
        [DisplayName("Mi Archivo:")]
        public HttpPostedFileBase File1 { get; set; }

        [Required]
        [DisplayName("Mi Archivo 2:")]
        public HttpPostedFileBase File2 { get; set; }

        [Required]
        [DisplayName("Mi Cadena:")]
        public string Cadena { get; set; }
    }
}