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
        [Display(Name ="Nome da atividade")]
        public string nome { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime data_at { get; set; }
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
        [Display(Name = "Avaliação")]
        public int avaliacao { get; set; }
    }
}