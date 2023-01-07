using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVCProject.Models
{
    public class VendedoresViewModel
    {
        public int Id { get; set; } = 0;

        //[Required(ErrorMessage = "O {0} é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        //[Required(ErrorMessage = "O {0} é obrigatório")]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set; } = string.Empty;

        //[Required(ErrorMessage = "O {0} é obrigatório")]
        //[DataType(DataType.Date)]
        //[Display(Name = "Data de Nascimento")]        
        public DateTime DataNascimento { get; set; }
    }
}
