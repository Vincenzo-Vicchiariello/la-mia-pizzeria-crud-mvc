using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaMiaPizzeriaNuova.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityAddCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PizzaCategoryId",
                table: "Pizze",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "pizzaCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizzaCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizze_PizzaCategoryId",
                table: "Pizze",
                column: "PizzaCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_pizzaCategories_PizzaCategoryId",
                table: "Pizze",
                column: "PizzaCategoryId",
                principalTable: "pizzaCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_pizzaCategories_PizzaCategoryId",
                table: "Pizze");

            migrationBuilder.DropTable(
                name: "pizzaCategories");

            migrationBuilder.DropIndex(
                name: "IX_Pizze_PizzaCategoryId",
                table: "Pizze");

            migrationBuilder.DropColumn(
                name: "PizzaCategoryId",
                table: "Pizze");
        }
    }
}
