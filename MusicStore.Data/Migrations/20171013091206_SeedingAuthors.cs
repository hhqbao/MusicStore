using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MusicStore.Data.Migrations
{
    public partial class SeedingAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(String.Format("Insert into Authors(Name) values('{0}')", "Charlie Puth"));
            migrationBuilder.Sql(String.Format("Insert into Authors(Name) values('{0}')", "Imagine Dragons"));
            migrationBuilder.Sql(String.Format("Insert into Authors(Name) values('{0}')", "Selena Gomez"));
            migrationBuilder.Sql(String.Format("Insert into Authors(Name) values('{0}')", "Taylor Swift"));
            migrationBuilder.Sql(String.Format("Insert into Authors(Name) values('{0}')", "Justin Bieber"));
            migrationBuilder.Sql(String.Format("Insert into Authors(Name) values('{0}')", "Various Artists"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From Authors");
        }
    }
}
