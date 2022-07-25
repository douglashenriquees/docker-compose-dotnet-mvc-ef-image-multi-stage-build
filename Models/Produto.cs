namespace mvc.Models;

public class Produto
{
    public int ProdutoId { get; set; }

    public string Nome { get; set; }

    public string Categoria { get; set; }

    public decimal Preco { get; set; }

    public Produto(string nome = "", string categoria = "", decimal preco = 0)
    {
        this.Nome = nome;
        this.Categoria = categoria;
        this.Preco = preco;
    }
}