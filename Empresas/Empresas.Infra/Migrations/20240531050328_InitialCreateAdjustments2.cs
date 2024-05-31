using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empresas.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAdjustments2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "IDENTITY_TOKEN_LIFETIME",
                table: "CLIENTS",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "IDENTITY_TOKEN_LIFETIME",
                table: "CLIENTS",
                type: "NUMERIC(12,0)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
