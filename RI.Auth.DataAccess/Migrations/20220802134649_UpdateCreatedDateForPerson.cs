using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RI.Auth.DataAccess.Migrations
{
    public partial class UpdateCreatedDateForPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Person",
                type: "timestamp(6) with time zone",
                precision: 6,
                nullable: false,
                defaultValueSql: "timezone('utc'::text, now())",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Person",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6) with time zone",
                oldPrecision: 6,
                oldDefaultValueSql: "timezone('utc'::text, now())");
        }
    }
}
