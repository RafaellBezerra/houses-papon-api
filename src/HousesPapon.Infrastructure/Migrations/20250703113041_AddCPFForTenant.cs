using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HousesPapon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCPFForTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Tenants",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Tenants");
        }
    }
}
