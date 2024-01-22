using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseCustomer.Application.DTOs
{
    public class DocumentoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do documento")]
        [MinLength(2)]
        [MaxLength(30)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o número do documento")]
        [MinLength(9)]
        [MaxLength(14)]
        public string Numero { get; set; }

    }
}
