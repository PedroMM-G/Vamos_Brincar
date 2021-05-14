using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using Vamos_Brincar.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vamos_Brincar.Models
{
    public class instituicaomod
    {
        public int id_inst { get; set; }
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Introduza o seu nome", AllowEmptyStrings = false)]
        public string nome { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Introduza o sua palavra-passe", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string pass { get; set; }
    }
}