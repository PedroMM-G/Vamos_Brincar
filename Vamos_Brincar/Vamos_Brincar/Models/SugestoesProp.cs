using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vamos_Brincar.Models
{
    public class SugestoesProp
    {
        public int id_sug { get; set; }
        public int id_crianca { get; set; }
        public int id_inst { get; set; }
        public string sug { get; set; }

    }
}