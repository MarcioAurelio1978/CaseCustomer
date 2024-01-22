using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseCustomer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PopulaClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Clientes(Nome,DataNascimento,Endereco,DataCadastro,ClienteAtivo,DocumentoId) " +
            "VALUES('João da Silva','1978-04-29','Av.Mogi nº 1','2024-01-22',1,1)");

            migrationBuilder.Sql("INSERT INTO Clientes(Nome,DataNascimento,Endereco,DataCadastro,ClienteAtivo,DocumentoId) " +
            "VALUES('Maria do Bairro','1981-04-12','Rua da Amora nº 1000','2024-01-22',1,2)");

            migrationBuilder.Sql("INSERT INTO Clientes(Nome,DataNascimento,Endereco,DataCadastro,ClienteAtivo,DocumentoId) " +
            "VALUES('Tyna Tunner','1990-05-01','Av.Cruzeiro do Sul nº 260','2024-01-22',1,1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
