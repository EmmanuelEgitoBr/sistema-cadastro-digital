using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestao.Cadastro.Digital.Infra.Sql.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PESSOA",
                columns: table => new
                {
                    IDPESSOA = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIPOPESSOA = table.Column<int>(type: "int", nullable: false),
                    CATEGORIAPESSOA = table.Column<int>(type: "int", nullable: false),
                    ContatoPessoa_IdContato = table.Column<long>(type: "bigint", nullable: false),
                    ContatoPessoa_IdPessoa = table.Column<long>(type: "bigint", nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContatoPessoa_Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoPessoa_IdEndereco = table.Column<long>(type: "bigint", nullable: false),
                    EnderecoPessoa_IdPessoa = table.Column<long>(type: "bigint", nullable: false),
                    LOGRADOURO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NUMERO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoPessoa_Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BAIRRO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIDADE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAREGISTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAINATIVACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TIPOPESSOA1 = table.Column<int>(type: "int", nullable: false),
                    IdPessoaFisica = table.Column<long>(type: "bigint", nullable: true),
                    NOMEPESSOA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NomePai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeMae = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    NumeroRg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgaoExpedidorRg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UfExpedidorRg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEmissaoRg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacionalidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CidadeNascimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UfNascimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATANASCIMENTO = table.Column<DateTime>(type: "date", nullable: true),
                    IdPessoaJuridica = table.Column<long>(type: "bigint", nullable: true),
                    NomeResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOMEFANTASIA = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RAZAOSOCIAL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InscricaoMunicipal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAFUNDACAO = table.Column<DateTime>(type: "date", nullable: true),
                    NaturezaJuridica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnae = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA", x => x.IDPESSOA);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    IDCLIENTE = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPESSOA = table.Column<long>(type: "bigint", nullable: false),
                    DATAINICIO = table.Column<DateTime>(type: "date", nullable: false),
                    DATAFIM = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.IDCLIENTE);
                    table.ForeignKey(
                        name: "FK_CLIENTE_PESSOA_IDPESSOA",
                        column: x => x.IDPESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "IDPESSOA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FORNECEDOR",
                columns: table => new
                {
                    IDFORNECEDOR = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPESSOA = table.Column<long>(type: "bigint", nullable: false),
                    DEPARTAMENTO = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DATAINICIO = table.Column<DateTime>(type: "date", nullable: false),
                    DATAFIM = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORNECEDOR", x => x.IDFORNECEDOR);
                    table.ForeignKey(
                        name: "FK_FORNECEDOR_PESSOA_IDPESSOA",
                        column: x => x.IDPESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "IDPESSOA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FUNCIONARIO",
                columns: table => new
                {
                    IDFUNCIONARIO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPESSOA = table.Column<long>(type: "bigint", nullable: false),
                    CARGO = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DEPARTAMENTO = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TIPOFUNCIONARIO = table.Column<int>(type: "int", nullable: false),
                    DATAADMISSAO = table.Column<DateTime>(type: "date", nullable: false),
                    DATADEMISSAO = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCIONARIO", x => x.IDFUNCIONARIO);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_PESSOA_IDPESSOA",
                        column: x => x.IDPESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "IDPESSOA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTE_IDPESSOA",
                table: "CLIENTE",
                column: "IDPESSOA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FORNECEDOR_IDPESSOA",
                table: "FORNECEDOR",
                column: "IDPESSOA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_IDPESSOA",
                table: "FUNCIONARIO",
                column: "IDPESSOA",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "FORNECEDOR");

            migrationBuilder.DropTable(
                name: "FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "PESSOA");
        }
    }
}
