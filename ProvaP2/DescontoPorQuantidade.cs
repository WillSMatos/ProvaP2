using System;
using System.Linq;
using LojaVirtual.Models;

namespace LojaVirtual.Discounts
{
    public class DescontoPorQuantidade : IDesconto
    {
        private readonly int quantidadeMinima;
        private readonly decimal percentualDesconto;

        public DescontoPorQuantidade(int quantidadeMinima, decimal percentualDesconto)
        {
            if (quantidadeMinima <= 0)
                throw new ArgumentException("Quantidade mínima deve ser maior que zero.");
            if (percentualDesconto < 0 || percentualDesconto > 1)
                throw new ArgumentException("Percentual de desconto deve estar entre 0 e 1.");
            this.quantidadeMinima = quantidadeMinima;
            this.percentualDesconto = percentualDesconto;
        }

        public decimal CalcularDesconto(Pedido pedido)
        {
            int quantidadeTotal = pedido.Itens.Sum(i => i.Quantidade);
            if (quantidadeTotal >= quantidadeMinima)
                return pedido.ValorTotal * percentualDesconto;
            return 0m;
        }
    }
}
