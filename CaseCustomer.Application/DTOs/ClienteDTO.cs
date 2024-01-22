using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseCustomer.Application.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(15)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        [MinLength(10)]
        [MaxLength(150)]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe a data do cadastro")]
        public DateTime DataCadastro { get; set; }

        public DateTime ClienteAtivo { get; set; }

        public int DocumentoId { get; set; }


    }
}
