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
        public Documento(string nome, string numero)
        {
            ValidateDomain(nome, numero);
        }

        public Documento(int id, string nome, string numero)
        {
            DomainExceptionValidation.When(id < 0, "valor de Id inválido.");
            Id = id;
            ValidateDomain(nome, numero);
        }


        public string Nome { get; private set; }
        public string Numero { get; private set; }
        public ICollection<Cliente> Clientes { get; set; }


        private void ValidateDomain(string nome, string numero)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(numero),
                "Número inválido. O numero é obrigatório");           

            Nome = nome;
            Numero = numero;
        }
    }
}
