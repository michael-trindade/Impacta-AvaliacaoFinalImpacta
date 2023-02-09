using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFuncionario.Data.Migrations
{
    public partial class valerefeicao03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ValeRefeicao",
                columns: table => new
                {
                    ValeRefeicaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qtde = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValeRefeicao", x => x.ValeRefeicaoId);
                    table.ForeignKey(
                        name: "FK_ValeRefeicao_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValeRefeicao_FuncionarioId",
                table: "ValeRefeicao",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValeRefeicao");
        }
    }
}
