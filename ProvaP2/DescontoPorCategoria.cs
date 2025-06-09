using System;
using LojaVirtual.Models;

namespace LojaVirtual.Discounts
{
    public class DescontoPorCategoria : IDesconto
    {
        private readonly string categoriaAlvo;
        private readonly decimal percentualDesconto;

        public DescontoPorCategoria(string categoriaAlvo, decimal percentualDesconto)
        {
            this.categoriaAlvo = categoriaAlvo ?? throw new ArgumentNullException(nameof(categoriaAlvo));
            if (percentualDesconto < 0 || percentualDesconto > 1)
                throw new ArgumentException("Percentual de desconto deve estar entre 0 e 1.");
            this.percentualDesconto = percentualDesconto;
        }

        public decimal CalcularDesconto(Pedido pedido)
        {
            decimal desconto = 0m;
            foreach (var item in pedido.Itens)
            {
                if (item.Produto.Categoria.Equals(categoriaAlvo, StringComparison.OrdinalIgnoreCase))
                {
                    desconto += item.CalcularTotal() * percentualDesconto;
                }
            }
            return desconto;
        }
    }
}
