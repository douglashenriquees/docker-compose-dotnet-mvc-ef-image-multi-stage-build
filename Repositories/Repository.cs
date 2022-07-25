using mvc.Models;

namespace mvc.Repositories;

public class Repository : IRepository
{
    private AppDbContext appDbContext;

    public IEnumerable<Produto>? Produtos => appDbContext.Produtos;

    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
}