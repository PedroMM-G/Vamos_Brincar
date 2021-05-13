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
    [Table("Criancamod", Schema ="dbo")]
    public class Criancamod
    {
    
        [Key]
        public int id_crianca { get; set; }
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informe o nome do usuário", AllowEmptyStrings = false)]
        public string nome { get; set; } 
        public int idade { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Informe a senha do usuário", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string pass { get; set; }
        
    }
}