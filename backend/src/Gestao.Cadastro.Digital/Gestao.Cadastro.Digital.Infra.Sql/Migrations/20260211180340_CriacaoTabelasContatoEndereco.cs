using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestao.Cadastro.Digital.Infra.Sql.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelasContatoEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContatoPessoa_Email",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "ContatoPessoa_Endereco",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "ContatoPessoa_IdContato",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "ContatoPessoa_IdPessoa",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "ContatoPessoa_Telefone",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "EnderecoPessoa_Bairro",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "EnderecoPessoa_Cep",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "EnderecoPessoa_Cidade",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "EnderecoPessoa_Complemento",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "EnderecoPessoa_Estado",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "EnderecoPessoa_IdEndereco",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "EnderecoPessoa_IdPessoa",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "EnderecoPessoa_Logradouro",
                table: "PESSOA");

            migrationBuilder.DropColumn(
                name: "EnderecoPessoa_Numero",
                table: "PESSOA");

            migrationBuilder.CreateTable(
                name: "CONTATO",
                columns: table => new
                {
                    IdContato = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPessoa = table.Column<long>(type: "bigint", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTATO", x => x.IdContato);
                    table.ForeignKey(
                        name: "FK_CONTATO_PESSOA_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "PESSOA",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    IdEndereco = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPessoa = table.Column<long>(type: "bigint", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.IdEndereco);
                    table.ForeignKey(
                        name: "FK_ENDERECO_PESSOA_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "PESSOA",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTATO_IdPessoa",
                table: "CONTATO",
                column: "IdPessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_IdPessoa",
                table: "ENDERECO",
                column: "IdPessoa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTATO");

            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.AddColumn<string>(
                name: "ContatoPessoa_Email",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContatoPessoa_Endereco",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ContatoPessoa_IdContato",
                table: "PESSOA",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ContatoPessoa_IdPessoa",
                table: "PESSOA",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "ContatoPessoa_Telefone",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPessoa_Bairro",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPessoa_Cep",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPessoa_Cidade",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPessoa_Complemento",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPessoa_Estado",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EnderecoPessoa_IdEndereco",
                table: "PESSOA",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EnderecoPessoa_IdPessoa",
                table: "PESSOA",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPessoa_Logradouro",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoPessoa_Numero",
                table: "PESSOA",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
