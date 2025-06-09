using System;

namespace LojaVirtual.Models
{
    public class Produto
    {
        public int Id { get; }
        public string Nome { get; }
        public decimal Preco { get; }
        public string Categoria { get; }

        public Produto(int id, string nome, decimal preco, string categoria)
        {
            if (preco < 0)
                throw new ArgumentException("Preço do produto não pode ser negativo.");
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do produto não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(categoria))
                throw new ArgumentException("Categoria do produto não pode ser vazia.");

            Id = id;
            Nome = nome;
            Preco = preco;
            Categoria = categoria;
        }
    }
}
