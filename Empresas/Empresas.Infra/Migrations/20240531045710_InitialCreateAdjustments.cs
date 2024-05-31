using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empresas.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAdjustments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "IDENTITY_TOKEN_LIFETIME",
                table: "CLIENTS",
                type: "NUMERIC(12,0)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(12)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "IDENTITY_TOKEN_LIFETIME",
                table: "CLIENTS",
                type: "NUMBER(12)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(12,0)");
        }
    }
}
