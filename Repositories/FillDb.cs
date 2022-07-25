using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Repositories;

public static class FillDb
{
    public static void FillDataDb(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var appDbContext = serviceScope.ServiceProvider.GetService<AppDbContext>() ?? new AppDbContext(new DbContextOptions<AppDbContext>());

            System.Console.WriteLine("Aplicando o Migrations...");

            appDbContext.Database.Migrate();

            var existeProduto = appDbContext.Produtos?.Any() ?? false;

            if (!existeProduto)
            {
                System.Console.WriteLine("Criando dados...");

                appDbContext.AddRange(
                    new Produto() { ProdutoId = 10, Nome = "Caneta", Categoria = "Material", Preco = 2.0M },
                    new Produto() { ProdutoId = 20, Nome = "Borracha", Categoria = "Material", Preco = 1.5M },
                    new Produto() { ProdutoId = 30, Nome = "Estojo", Categoria = "Material", Preco = 3.0M }
                );

                appDbContext.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Dados já existem...");
            }
        }
    }
}