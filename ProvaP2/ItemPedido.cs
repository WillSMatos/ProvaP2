using System;

namespace LojaVirtual.Models
{
    public class ItemPedido
    {
        public Produto Produto { get; }
        public int Quantidade { get; }

        public ItemPedido(Produto produto, int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");

            Produto = produto ?? throw new ArgumentNullException(nameof(produto));
            Quantidade = quantidade;
        }

        public decimal CalcularTotal()
        {
            return Produto.Preco * Quantidade;
        }
    }
}
