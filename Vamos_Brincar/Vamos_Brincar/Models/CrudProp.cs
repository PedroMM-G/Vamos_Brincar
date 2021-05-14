using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vamos_Brincar.Models
{
    public class CrudProp
    {
        public int id_atividade { get; set; }
        public string nome { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime data_at { get; set; }
        public string descricao { get; set; }
        public int avaliacao { get; set; }
    }
}