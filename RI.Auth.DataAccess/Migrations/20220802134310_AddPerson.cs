using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RI.Auth.DataAccess.Migrations
{
    public partial class AddPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(50)", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(100)", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
