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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquilinos", x => x.Id);
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
                    InquilinosId_Inquilino = table.Column<int>(type: "int", nullable: false),
                    InquilinosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id_Unidade);
                    table.ForeignKey(
                        name: "FK_Unidades_Inquilinos_InquilinosId",
                        column: x => x.InquilinosId,
                        principalTable: "Inquilinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UnidadeId_unidade = table.Column<int>(type: "int", nullable: false),
                    UnidadesId_Unidade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id_Despesa);
                    table.ForeignKey(
                        name: "FK_Despesas_Unidades_UnidadesId_Unidade",
                        column: x => x.UnidadesId_Unidade,
                        principalTable: "Unidades",
                        principalColumn: "Id_Unidade",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_UnidadesId_Unidade",
                table: "Despesas",
                column: "UnidadesId_Unidade");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_InquilinosId",
                table: "Unidades",
                column: "InquilinosId");
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
