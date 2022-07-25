using mvc.Models;

namespace mvc.Repositories;

public interface IRepository
{
    IEnumerable<Produto>? Produtos { get; }
}