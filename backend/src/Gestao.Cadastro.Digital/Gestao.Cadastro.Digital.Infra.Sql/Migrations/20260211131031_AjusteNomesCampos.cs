using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestao.Cadastro.Digital.Infra.Sql.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNomesCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTE_PESSOA_IDPESSOA",
                table: "CLIENTE");

            migrationBuilder.DropForeignKey(
                name: "FK_FORNECEDOR_PESSOA_IDPESSOA",
                table: "FORNECEDOR");

            migrationBuilder.DropForeignKey(
                name: "FK_FUNCIONARIO_PESSOA_IDPESSOA",
                table: "FUNCIONARIO");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAFISICA_PESSOA_IDPESSOA",
                table: "PESSOAFISICA");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAJURIDICA_PESSOA_IDPESSOA",
                table: "PESSOAJURIDICA");

            migrationBuilder.RenameColumn(
                name: "RAZAOSOCIAL",
                table: "PESSOAJURIDICA",
                newName: "RazaoSocial");

            migrationBuilder.RenameColumn(
                name: "NOMEFANTASIA",
                table: "PESSOAJURIDICA",
                newName: "NomeFantasia");

            migrationBuilder.RenameColumn(
                name: "DATAFUNDACAO",
                table: "PESSOAJURIDICA",
                newName: "DataFundacao");

            migrationBuilder.RenameColumn(
                name: "CNPJ",
                table: "PESSOAJURIDICA",
                newName: "Cnpj");

            migrationBuilder.RenameColumn(
                name: "IDPESSOA",
                table: "PESSOAJURIDICA",
                newName: "IdPessoa");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOAJURIDICA_IDPESSOA",
                table: "PESSOAJURIDICA",
                newName: "IX_PESSOAJURIDICA_IdPessoa");

            migrationBuilder.RenameColumn(
                name: "NOMEPESSOA",
                table: "PESSOAFISICA",
                newName: "NomePessoa");

            migrationBuilder.RenameColumn(
                name: "DATANASCIMENTO",
                table: "PESSOAFISICA",
                newName: "DataNascimento");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "PESSOAFISICA",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "IDPESSOA",
                table: "PESSOAFISICA",
                newName: "IdPessoa");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOAFISICA_IDPESSOA",
                table: "PESSOAFISICA",
                newName: "IX_PESSOAFISICA_IdPessoa");

            migrationBuilder.RenameColumn(
                name: "TIPOPESSOA",
                table: "PESSOA",
                newName: "TipoPessoa");

            migrationBuilder.RenameColumn(
                name: "DATAREGISTRO",
                table: "PESSOA",
                newName: "DataRegistro");

            migrationBuilder.RenameColumn(
                name: "DATAINATIVACAO",
                table: "PESSOA",
                newName: "DataInativacao");

            migrationBuilder.RenameColumn(
                name: "CATEGORIAPESSOA",
                table: "PESSOA",
                newName: "CategoriaPessoa");

            migrationBuilder.RenameColumn(
                name: "IDPESSOA",
                table: "PESSOA",
                newName: "IdPessoa");

            migrationBuilder.RenameColumn(
                name: "UF",
                table: "PESSOA",
                newName: "EnderecoPessoa_Estado");

            migrationBuilder.RenameColumn(
                name: "TELEFONE",
                table: "PESSOA",
                newName: "ContatoPessoa_Telefone");

            migrationBuilder.RenameColumn(
                name: "NUMERO",
                table: "PESSOA",
                newName: "EnderecoPessoa_Numero");

            migrationBuilder.RenameColumn(
                name: "LOGRADOURO",
                table: "PESSOA",
                newName: "EnderecoPessoa_Logradouro");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "PESSOA",
                newName: "ContatoPessoa_Email");

            migrationBuilder.RenameColumn(
                name: "CIDADE",
                table: "PESSOA",
                newName: "EnderecoPessoa_Cidade");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "PESSOA",
                newName: "EnderecoPessoa_Cep");

            migrationBuilder.RenameColumn(
                name: "BAIRRO",
                table: "PESSOA",
                newName: "EnderecoPessoa_Bairro");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOA_IDPESSOA",
                table: "PESSOA",
                newName: "IX_PESSOA_IdPessoa");

            migrationBuilder.RenameColumn(
                name: "TIPOFUNCIONARIO",
                table: "FUNCIONARIO",
                newName: "TipoFuncionario");

            migrationBuilder.RenameColumn(
                name: "IDPESSOA",
                table: "FUNCIONARIO",
                newName: "IdPessoa");

            migrationBuilder.RenameColumn(
                name: "DEPARTAMENTO",
                table: "FUNCIONARIO",
                newName: "Departamento");

            migrationBuilder.RenameColumn(
                name: "DATADEMISSAO",
                table: "FUNCIONARIO",
                newName: "DataDemissao");

            migrationBuilder.RenameColumn(
                name: "DATAADMISSAO",
                table: "FUNCIONARIO",
                newName: "DataAdmissao");

            migrationBuilder.RenameColumn(
                name: "CARGO",
                table: "FUNCIONARIO",
                newName: "Cargo");

            migrationBuilder.RenameColumn(
                name: "IDFUNCIONARIO",
                table: "FUNCIONARIO",
                newName: "IdFuncionario");

            migrationBuilder.RenameIndex(
                name: "IX_FUNCIONARIO_IDPESSOA",
                table: "FUNCIONARIO",
                newName: "IX_FUNCIONARIO_IdPessoa");

            migrationBuilder.RenameColumn(
                name: "IDPESSOA",
                table: "FORNECEDOR",
                newName: "IdPessoa");

            migrationBuilder.RenameColumn(
                name: "DEPARTAMENTO",
                table: "FORNECEDOR",
                newName: "Departamento");

            migrationBuilder.RenameColumn(
                name: "DATAINICIO",
                table: "FORNECEDOR",
                newName: "DataInicio");

            migrationBuilder.RenameColumn(
                name: "DATAFIM",
                table: "FORNECEDOR",
                newName: "DataFim");

            migrationBuilder.RenameColumn(
                name: "IDFORNECEDOR",
                table: "FORNECEDOR",
                newName: "IdFornecedor");

            migrationBuilder.RenameIndex(
                name: "IX_FORNECEDOR_IDPESSOA",
                table: "FORNECEDOR",
                newName: "IX_FORNECEDOR_IdPessoa");

            migrationBuilder.RenameColumn(
                name: "IDPESSOA",
                table: "CLIENTE",
                newName: "IdPessoa");

            migrationBuilder.RenameColumn(
                name: "DATAINICIO",
                table: "CLIENTE",
                newName: "DataInicio");

            migrationBuilder.RenameColumn(
                name: "DATAFIM",
                table: "CLIENTE",
                newName: "DataFim");

            migrationBuilder.RenameColumn(
                name: "IDCLIENTE",
                table: "CLIENTE",
                newName: "IdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_CLIENTE_IDPESSOA",
                table: "CLIENTE",
                newName: "IX_CLIENTE_IdPessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTE_PESSOA_IdPessoa",
                table: "CLIENTE",
                column: "IdPessoa",
                principalTable: "PESSOA",
                principalColumn: "IdPessoa",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FORNECEDOR_PESSOA_IdPessoa",
                table: "FORNECEDOR",
                column: "IdPessoa",
                principalTable: "PESSOA",
                principalColumn: "IdPessoa",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FUNCIONARIO_PESSOA_IdPessoa",
                table: "FUNCIONARIO",
                column: "IdPessoa",
                principalTable: "PESSOA",
                principalColumn: "IdPessoa",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAFISICA_PESSOA_IdPessoa",
                table: "PESSOAFISICA",
                column: "IdPessoa",
                principalTable: "PESSOA",
                principalColumn: "IdPessoa",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAJURIDICA_PESSOA_IdPessoa",
                table: "PESSOAJURIDICA",
                column: "IdPessoa",
                principalTable: "PESSOA",
                principalColumn: "IdPessoa",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTE_PESSOA_IdPessoa",
                table: "CLIENTE");

            migrationBuilder.DropForeignKey(
                name: "FK_FORNECEDOR_PESSOA_IdPessoa",
                table: "FORNECEDOR");

            migrationBuilder.DropForeignKey(
                name: "FK_FUNCIONARIO_PESSOA_IdPessoa",
                table: "FUNCIONARIO");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAFISICA_PESSOA_IdPessoa",
                table: "PESSOAFISICA");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAJURIDICA_PESSOA_IdPessoa",
                table: "PESSOAJURIDICA");

            migrationBuilder.RenameColumn(
                name: "RazaoSocial",
                table: "PESSOAJURIDICA",
                newName: "RAZAOSOCIAL");

            migrationBuilder.RenameColumn(
                name: "NomeFantasia",
                table: "PESSOAJURIDICA",
                newName: "NOMEFANTASIA");

            migrationBuilder.RenameColumn(
                name: "DataFundacao",
                table: "PESSOAJURIDICA",
                newName: "DATAFUNDACAO");

            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "PESSOAJURIDICA",
                newName: "CNPJ");

            migrationBuilder.RenameColumn(
                name: "IdPessoa",
                table: "PESSOAJURIDICA",
                newName: "IDPESSOA");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOAJURIDICA_IdPessoa",
                table: "PESSOAJURIDICA",
                newName: "IX_PESSOAJURIDICA_IDPESSOA");

            migrationBuilder.RenameColumn(
                name: "NomePessoa",
                table: "PESSOAFISICA",
                newName: "NOMEPESSOA");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "PESSOAFISICA",
                newName: "DATANASCIMENTO");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "PESSOAFISICA",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "IdPessoa",
                table: "PESSOAFISICA",
                newName: "IDPESSOA");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOAFISICA_IdPessoa",
                table: "PESSOAFISICA",
                newName: "IX_PESSOAFISICA_IDPESSOA");

            migrationBuilder.RenameColumn(
                name: "TipoPessoa",
                table: "PESSOA",
                newName: "TIPOPESSOA");

            migrationBuilder.RenameColumn(
                name: "DataRegistro",
                table: "PESSOA",
                newName: "DATAREGISTRO");

            migrationBuilder.RenameColumn(
                name: "DataInativacao",
                table: "PESSOA",
                newName: "DATAINATIVACAO");

            migrationBuilder.RenameColumn(
                name: "CategoriaPessoa",
                table: "PESSOA",
                newName: "CATEGORIAPESSOA");

            migrationBuilder.RenameColumn(
                name: "IdPessoa",
                table: "PESSOA",
                newName: "IDPESSOA");

            migrationBuilder.RenameColumn(
                name: "EnderecoPessoa_Numero",
                table: "PESSOA",
                newName: "NUMERO");

            migrationBuilder.RenameColumn(
                name: "EnderecoPessoa_Logradouro",
                table: "PESSOA",
                newName: "LOGRADOURO");

            migrationBuilder.RenameColumn(
                name: "EnderecoPessoa_Estado",
                table: "PESSOA",
                newName: "UF");

            migrationBuilder.RenameColumn(
                name: "EnderecoPessoa_Cidade",
                table: "PESSOA",
                newName: "CIDADE");

            migrationBuilder.RenameColumn(
                name: "EnderecoPessoa_Cep",
                table: "PESSOA",
                newName: "CEP");

            migrationBuilder.RenameColumn(
                name: "EnderecoPessoa_Bairro",
                table: "PESSOA",
                newName: "BAIRRO");

            migrationBuilder.RenameColumn(
                name: "ContatoPessoa_Telefone",
                table: "PESSOA",
                newName: "TELEFONE");

            migrationBuilder.RenameColumn(
                name: "ContatoPessoa_Email",
                table: "PESSOA",
                newName: "EMAIL");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOA_IdPessoa",
                table: "PESSOA",
                newName: "IX_PESSOA_IDPESSOA");

            migrationBuilder.RenameColumn(
                name: "TipoFuncionario",
                table: "FUNCIONARIO",
                newName: "TIPOFUNCIONARIO");

            migrationBuilder.RenameColumn(
                name: "IdPessoa",
                table: "FUNCIONARIO",
                newName: "IDPESSOA");

            migrationBuilder.RenameColumn(
                name: "Departamento",
                table: "FUNCIONARIO",
                newName: "DEPARTAMENTO");

            migrationBuilder.RenameColumn(
                name: "DataDemissao",
                table: "FUNCIONARIO",
                newName: "DATADEMISSAO");

            migrationBuilder.RenameColumn(
                name: "DataAdmissao",
                table: "FUNCIONARIO",
                newName: "DATAADMISSAO");

            migrationBuilder.RenameColumn(
                name: "Cargo",
                table: "FUNCIONARIO",
                newName: "CARGO");

            migrationBuilder.RenameColumn(
                name: "IdFuncionario",
                table: "FUNCIONARIO",
                newName: "IDFUNCIONARIO");

            migrationBuilder.RenameIndex(
                name: "IX_FUNCIONARIO_IdPessoa",
                table: "FUNCIONARIO",
                newName: "IX_FUNCIONARIO_IDPESSOA");

            migrationBuilder.RenameColumn(
                name: "IdPessoa",
                table: "FORNECEDOR",
                newName: "IDPESSOA");

            migrationBuilder.RenameColumn(
                name: "Departamento",
                table: "FORNECEDOR",
                newName: "DEPARTAMENTO");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "FORNECEDOR",
                newName: "DATAINICIO");

            migrationBuilder.RenameColumn(
                name: "DataFim",
                table: "FORNECEDOR",
                newName: "DATAFIM");

            migrationBuilder.RenameColumn(
                name: "IdFornecedor",
                table: "FORNECEDOR",
                newName: "IDFORNECEDOR");

            migrationBuilder.RenameIndex(
                name: "IX_FORNECEDOR_IdPessoa",
                table: "FORNECEDOR",
                newName: "IX_FORNECEDOR_IDPESSOA");

            migrationBuilder.RenameColumn(
                name: "IdPessoa",
                table: "CLIENTE",
                newName: "IDPESSOA");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "CLIENTE",
                newName: "DATAINICIO");

            migrationBuilder.RenameColumn(
                name: "DataFim",
                table: "CLIENTE",
                newName: "DATAFIM");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "CLIENTE",
                newName: "IDCLIENTE");

            migrationBuilder.RenameIndex(
                name: "IX_CLIENTE_IdPessoa",
                table: "CLIENTE",
                newName: "IX_CLIENTE_IDPESSOA");

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTE_PESSOA_IDPESSOA",
                table: "CLIENTE",
                column: "IDPESSOA",
                principalTable: "PESSOA",
                principalColumn: "IDPESSOA",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FORNECEDOR_PESSOA_IDPESSOA",
                table: "FORNECEDOR",
                column: "IDPESSOA",
                principalTable: "PESSOA",
                principalColumn: "IDPESSOA",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FUNCIONARIO_PESSOA_IDPESSOA",
                table: "FUNCIONARIO",
                column: "IDPESSOA",
                principalTable: "PESSOA",
                principalColumn: "IDPESSOA",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAFISICA_PESSOA_IDPESSOA",
                table: "PESSOAFISICA",
                column: "IDPESSOA",
                principalTable: "PESSOA",
                principalColumn: "IDPESSOA",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAJURIDICA_PESSOA_IDPESSOA",
                table: "PESSOAJURIDICA",
                column: "IDPESSOA",
                principalTable: "PESSOA",
                principalColumn: "IDPESSOA",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
