using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vamos_Brincar.Models
{
    public class SugestoesProp
    {
        public int id_sug { get; set; }
        public int id_crianca { get; set; }
        public int id_inst { get; set; }
        [Display(Name = "Sugestões")]
        public string sug { get; set; }

    }
}