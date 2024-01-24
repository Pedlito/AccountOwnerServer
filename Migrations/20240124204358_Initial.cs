using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AccountOwnerServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "owner_acount");

            migrationBuilder.CreateTable(
                name: "owner",
                schema: "owner_acount",
                columns: table => new
                {
                    code = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: false),
                    address = table.Column<string>(type: "varchar(150)", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: true),
                    create_user = table.Column<short>(type: "smallint", nullable: false),
                    update_user = table.Column<short>(type: "smallint", nullable: false),
                    is_enable = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "acount",
                schema: "owner_acount",
                columns: table => new
                {
                    code = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    account_type = table.Column<string>(type: "varchar(50)", nullable: false),
                    owner_code = table.Column<short>(type: "smallint", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: true),
                    delete_date = table.Column<DateTime>(type: "timestamp(0) without time zone", nullable: true),
                    create_user = table.Column<short>(type: "smallint", nullable: false),
                    update_user = table.Column<short>(type: "smallint", nullable: false),
                    is_enable = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acount", x => x.code);
                    table.ForeignKey(
                        name: "FK_acount_owner_owner_code",
                        column: x => x.owner_code,
                        principalSchema: "owner_acount",
                        principalTable: "owner",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_acount_owner_code",
                schema: "owner_acount",
                table: "acount",
                column: "owner_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acount",
                schema: "owner_acount");

            migrationBuilder.DropTable(
                name: "owner",
                schema: "owner_acount");
        }
    }
}
