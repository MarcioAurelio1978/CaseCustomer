﻿using CaseCustomer.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseCustomer.Domain.Entities
{

    public sealed class Cliente : Entity
    {

        public Cliente(string nome, DateTime dataNascimento, string endereco, DateTime dataCadastro,bool clienteAtivo)
        {
            ValidateDomain(nome, dataNascimento, endereco, dataCadastro, clienteAtivo);
        }

        public string Nome { get;private set; }
        public DateTime DataNascimento { get;private set; }
        public string Endereco { get;private set; }
        public DateTime DataCadastro { get;private set; }
        public bool ClienteAtivo { get; private set; }
        public int DocumentoId { get; set; }
        public Documento Documento { get; set; }

        public void Update(string nome, DateTime dataNascimento, string endereco, DateTime dataCadastro,bool clienteAtivo, int documentoId)
        {
            ValidateDomain(nome, dataNascimento, endereco, dataCadastro, clienteAtivo);
            DocumentoId = documentoId;
        }

        private void ValidateDomain(string nome, DateTime dataNascimento, string endereco, DateTime dataCadastro,bool clienteAtivo)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(nome.Length < 15,
                "O nome deve ter no mínimo 15 caracteres");


            DomainExceptionValidation.When(string.IsNullOrEmpty(endereco),
                "Descrição inválida. O endereço é obrigatóroa");          

  

            

            Nome = nome;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            DataCadastro = dataCadastro;
            ClienteAtivo = clienteAtivo;          
        }
    }
}

