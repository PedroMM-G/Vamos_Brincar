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
    public partial class Instituicaomod
    {

        public int id_inst { get; set; }
        [Display(Name ="Nome da instituição")]
        public string nome { get; set; }
        [Display(Name = "Palavra-passe")]
        public string pass { get; set; }
    }
}