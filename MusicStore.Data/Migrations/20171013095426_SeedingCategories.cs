using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MusicStore.Data.Migrations
{
    public partial class SeedingCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(String.Format("Insert into Categories(Name) values('{0}')", "Rock & Roll"));
            migrationBuilder.Sql(String.Format("Insert into Categories(Name) values('{0}')", "Jazz"));
            migrationBuilder.Sql(String.Format("Insert into Categories(Name) values('{0}')", "Blue"));
            migrationBuilder.Sql(String.Format("Insert into Categories(Name) values('{0}')", "Classic"));
            migrationBuilder.Sql(String.Format("Insert into Categories(Name) values('{0}')", "Electro"));
            migrationBuilder.Sql(String.Format("Insert into Categories(Name) values('{0}')", "Various"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From Categories");
        }
    }
}
