using CaseCustomer.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseCustomer.Domain.Entities
{

    public sealed class Cliente : Entity
    {

        public Cliente(string nome, DateTime dataNascimento, string endereco,string documentoNumero, DateTime dataCadastro,bool clienteAtivo)
        {
            ValidateDomain(nome, dataNascimento, endereco, documentoNumero, dataCadastro, clienteAtivo);
        }

        public string Nome { get;private set; }
        public DateTime DataNascimento { get;private set; }
        public string Endereco { get;private set; }
        public string DocumentoNumero { get;private set; }
        public DateTime DataCadastro { get;private set; }
        public bool ClienteAtivo { get; private set; }
        public int DocumentoId { get; set; }
        public Documento Documento { get; set; }

        public void Update(string nome, DateTime dataNascimento, string endereco, string documentoNumero, DateTime dataCadastro,bool clienteAtivo, int documentoId)
        {
            ValidateDomain(nome, dataNascimento, endereco,documentoNumero, dataCadastro, clienteAtivo);
            DocumentoId = documentoId;
        }

        //opção de validação direto na entidade para somente oque for prioritario ex: email, docs 
        private void ValidateDomain(string nome, DateTime dataNascimento, string endereco,string documentoNumero, DateTime dataCadastro,bool clienteAtivo)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(nome.Length < 3,
                "O nome deve ter no mínimo 3 caracteres");


            DomainExceptionValidation.When(string.IsNullOrEmpty(endereco),
                "Endereço inválido. O endereço é obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(documentoNumero),
               "Número do documento inválido. O número do documento é obrigatório");


            Nome = nome;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            DocumentoNumero = documentoNumero;
            DataCadastro = dataCadastro;
            ClienteAtivo = clienteAtivo;          
        }
    }
}


