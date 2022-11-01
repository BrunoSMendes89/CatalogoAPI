using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder md)
        {
            md.Sql("insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID)" 
                + "Values('Coca-Cola Diet','Refrigerante de Cola 2lts',5.45, 'cocacola.png', 50, now(),1)");

            md.Sql("insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID)"
                + "Values('Lanchao D'avo','Baguete Varios Sabores',14.99, 'lanchao.png', 200, now(),2)");

            md.Sql("insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID)"
                + "Values('Petit Gateau Oreo','Petit Gateau Oreo Nestle',18.50, 'petitgateauoreo.png', 7, now(),3)");
        }

        protected override void Down(MigrationBuilder md)
        {
            md.Sql("delete from Produtos");
        }
    }
}
