using Microsoft.EntityFrameworkCore.Migrations;
using System.Data;

#nullable disable

namespace ApiCatalogo.Migrations
{
    public partial class PopulaCategorias : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into Categorias(Nome, ImagemUrl) values ('Bebidas', 'bebidas.png')");
            mb.Sql("insert into Categorias(Nome, ImagemUrl) values ('Lanches', 'lanches.png')");
            mb.Sql("insert into Categorias(Nome, ImagemUrl) values ('Sobremesas', 'Sobremesas.png')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Categorias");
        }
    }
}
