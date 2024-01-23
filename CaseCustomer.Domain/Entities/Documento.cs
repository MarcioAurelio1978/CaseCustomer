using CaseCustomer.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseCustomer.Domain.Entities
{
    public sealed class Documento : Entity
    {
        public Documento(string nome)
        {
            ValidateDomain(nome);
        }

        public Documento(int id, string nome)
        {
            DomainExceptionValidation.When(id < 0, "valor de Id inválido.");
            Id = id;
            ValidateDomain(nome);
        }


        public string Nome { get; private set; }   
        public ICollection<Cliente> Clientes { get; set; }



        private void ValidateDomain(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");
           
            Nome = nome;     
        }
    }
}
