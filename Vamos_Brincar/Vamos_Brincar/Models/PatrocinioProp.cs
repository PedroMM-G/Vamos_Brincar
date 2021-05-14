using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vamos_Brincar.Models
{
    public class PatrocinioProp
    {
        public int id_parceiro { get; set; }
        [Display(Name="Nome da instituicção")]
        public string nome { get; set; }
        [Display(Name = "Palavra-passe")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string descricao { get; set; }

    }
}