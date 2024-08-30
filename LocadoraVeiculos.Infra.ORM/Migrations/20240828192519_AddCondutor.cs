using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    /// <inheritdoc />
    public partial class AddCondutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBCliente_EnderecoId",
                table: "TBCliente");

            migrationBuilder.CreateTable(
                name: "DBCondutor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(25)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    NumeroCNH = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBCondutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBCondutor_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCliente_EnderecoId",
                table: "TBCliente",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_DBCondutor_ClienteId",
                table: "DBCondutor",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBCondutor");

            migrationBuilder.DropIndex(
                name: "IX_TBCliente_EnderecoId",
                table: "TBCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TBCliente_EnderecoId",
                table: "TBCliente",
                column: "EnderecoId",
                unique: true);
        }
    }
}
