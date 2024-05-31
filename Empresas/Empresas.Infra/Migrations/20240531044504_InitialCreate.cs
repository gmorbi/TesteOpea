using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empresas.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "API_SCOPES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    ENABLE = table.Column<bool>(type: "bit", nullable: true),
                    NAME = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DISPLAY_NAME = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_SCOPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    ENABLED = table.Column<bool>(type: "bit", nullable: true),
                    CLIENT_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    PROTOCOL_TYPE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    REQUIRE_CLIENT_SECRET = table.Column<bool>(type: "bit", nullable: true),
                    CLIENT_NAME = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    IDENTITY_TOKEN_LIFETIME = table.Column<long>(type: "NUMBER(12)", nullable: false),
                    CREATED = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EMPRESAS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    NOME = table.Column<string>(type: "Varchar(200)", nullable: false),
                    PORTE = table.Column<string>(type: "Varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT_GRANT_TYPES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    GRANT_TYPE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CLIENT_ID = table.Column<Guid>(type: "UniqueIdentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_GRANT_TYPES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLIENT_GRANT_TYPES_CLIENTS_CLIENT_ID",
                        column: x => x.CLIENT_ID,
                        principalTable: "CLIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT_SCOPES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    SCOPE_ID = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    CLIENT_ID = table.Column<Guid>(type: "UniqueIdentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_SCOPES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLIENT_SCOPES_API_SCOPES_SCOPE_ID",
                        column: x => x.SCOPE_ID,
                        principalTable: "API_SCOPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CLIENT_SCOPES_CLIENTS_CLIENT_ID",
                        column: x => x.CLIENT_ID,
                        principalTable: "CLIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT_SECRETS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    VALUE = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    EXPIRATION = table.Column<DateTime>(type: "DATE", nullable: true),
                    TYPE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CREATED = table.Column<DateTime>(type: "DATE", nullable: true),
                    CLIENT_ID = table.Column<Guid>(type: "UniqueIdentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_SECRETS", x => x.ID);
                    table.ForeignKey(
                        name: "SYS_C00152414",
                        column: x => x.CLIENT_ID,
                        principalTable: "CLIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_GRANT_TYPES_CLIENT_ID",
                table: "CLIENT_GRANT_TYPES",
                column: "CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_SCOPES_CLIENT_ID",
                table: "CLIENT_SCOPES",
                column: "CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_SCOPES_SCOPE_ID",
                table: "CLIENT_SCOPES",
                column: "SCOPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_SECRETS_CLIENT_ID",
                table: "CLIENT_SECRETS",
                column: "CLIENT_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENT_GRANT_TYPES");

            migrationBuilder.DropTable(
                name: "CLIENT_SCOPES");

            migrationBuilder.DropTable(
                name: "CLIENT_SECRETS");

            migrationBuilder.DropTable(
                name: "EMPRESAS");

            migrationBuilder.DropTable(
                name: "API_SCOPES");

            migrationBuilder.DropTable(
                name: "CLIENTS");
        }
    }
}
