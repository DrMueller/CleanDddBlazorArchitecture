using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mmu.CleanBlazor.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Individuallength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Length",
                schema: "Individuals",
                table: "Individual",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Length",
                schema: "Individuals",
                table: "Individual");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "Individuals",
                table: "Organisation",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "Individuals",
                table: "Individual",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
