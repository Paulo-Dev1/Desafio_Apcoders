using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAp.Migrations
{
    public partial class CondominioAp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inquilinos",
                columns: table => new
                {
                    Id_Inquilino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquilinos", x => x.Id_Inquilino);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Id_Unidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Propietario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condominio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InquilinosId_Inquilino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id_Unidade);
                    table.ForeignKey(
                        name: "FK_Unidades_Inquilinos_InquilinosId_Inquilino",
                        column: x => x.InquilinosId_Inquilino,
                        principalTable: "Inquilinos",
                        principalColumn: "Id_Inquilino",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id_Despesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo_Despesa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vencimento_Fatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_Pagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadesId_unidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id_Despesa);
                    table.ForeignKey(
                        name: "FK_Despesas_Unidades_UnidadesId_unidade",
                        column: x => x.UnidadesId_unidade,
                        principalTable: "Unidades",
                        principalColumn: "Id_Unidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_UnidadesId_unidade",
                table: "Despesas",
                column: "UnidadesId_unidade");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_InquilinosId_Inquilino",
                table: "Unidades",
                column: "InquilinosId_Inquilino");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "Inquilinos");
        }
    }
}
