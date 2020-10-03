using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Equinox.Infra.Data.Migrations
{
    public partial class Create_Personal_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Personals",
               columns: table => new
               {
                   Id = table.Column<Guid>(nullable: false),
                   BirthDate = table.Column<DateTime>(nullable: false),
                   Email = table.Column<string>(type: "varchar(100)", maxLength: 11, nullable: false),
                   Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Personals", x => x.Id);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personals");
        }
    }
}