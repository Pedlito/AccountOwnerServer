using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AccountOwnerServer.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "authentication");

            migrationBuilder.CreateTable(
                name: "user",
                schema: "authentication",
                columns: table => new
                {
                    code = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "varchar(50)", nullable: false),
                    first_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    last_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    password = table.Column<string>(type: "varchar(50)", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: true),
                    create_user = table.Column<short>(type: "smallint", nullable: false),
                    update_user = table.Column<short>(type: "smallint", nullable: true),
                    is_enable = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.code);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user",
                schema: "authentication");
        }
    }
}
