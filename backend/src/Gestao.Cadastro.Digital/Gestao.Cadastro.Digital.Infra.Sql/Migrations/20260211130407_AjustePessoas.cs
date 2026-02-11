using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestao.Cadastro.Digital.Infra.Sql.Migrations
{
    /// <inheritdoc />
    public partial class AjustePessoas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "CidadeNascimento",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "Cnae",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "DATAFUNDACAO",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "DATANASCIMENTO",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "DataEmissaoRg",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "EstadoCivil",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "IdPessoaFisica",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "IdPessoaJuridica",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "InscricaoEstadual",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "InscricaoMunicipal",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "NOMEFANTASIA",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "NOMEPESSOA",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "Nacionalidade",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "NaturezaJuridica",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "NomeMae",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "NomePai",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "NomeResponsavel",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "NumeroRg",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "OrgaoExpedidorRg",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "RAZAOSOCIAL",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "TIPOPESSOA1",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "UfExpedidorRg",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "UfNascimento",
                table: "PESSOA");

            migrationBuilder.CreateTable(
                name: "PESSOAFISICA",
                columns: table => new
                {
                    IDPESSOA = table.Column<long>(type: "bigint", nullable: false),
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
                    DATANASCIMENTO = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOAFISICA", x => x.IDPESSOA);
                    table.ForeignKey(
                        name: "FK_PESSOAFISICA_PESSOA_IDPESSOA",
                        column: x => x.IDPESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "IDPESSOA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PESSOAJURIDICA",
                columns: table => new
                {
                    IDPESSOA = table.Column<long>(type: "bigint", nullable: false),
                    NomeResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOMEFANTASIA = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RAZAOSOCIAL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InscricaoMunicipal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAFUNDACAO = table.Column<DateTime>(type: "date", nullable: false),
                    NaturezaJuridica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnae = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOAJURIDICA", x => x.IDPESSOA);
                    table.ForeignKey(
                        name: "FK_PESSOAJURIDICA_PESSOA_IDPESSOA",
                        column: x => x.IDPESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "IDPESSOA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_IDPESSOA",
                table: "PESSOA",
                column: "IDPESSOA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAFISICA_IDPESSOA",
                table: "PESSOAFISICA",
                column: "IDPESSOA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAJURIDICA_IDPESSOA",
                table: "PESSOAJURIDICA",
                column: "IDPESSOA",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PESSOAFISICA");

            migrationBuilder.DropTable(
                name: "PESSOAJURIDICA");

            migrationBuilder.DropIndex(
                name: "IX_PESSOA_IDPESSOA",
                table: "PESSOA");

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "PESSOA",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "PESSOA",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CidadeNascimento",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cnae",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAFUNDACAO",
                table: "PESSOA",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATANASCIMENTO",
                table: "PESSOA",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEmissaoRg",
                table: "PESSOA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstadoCivil",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdPessoaFisica",
                table: "PESSOA",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdPessoaJuridica",
                table: "PESSOA",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InscricaoEstadual",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InscricaoMunicipal",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOMEFANTASIA",
                table: "PESSOA",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOMEPESSOA",
                table: "PESSOA",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidade",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NaturezaJuridica",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeMae",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomePai",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeResponsavel",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroRg",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrgaoExpedidorRg",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RAZAOSOCIAL",
                table: "PESSOA",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TIPOPESSOA1",
                table: "PESSOA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UfExpedidorRg",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UfNascimento",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
