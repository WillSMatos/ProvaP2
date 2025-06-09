using System;
using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Discounts;
using LojaVirtual.Logging;

namespace LojaVirtual.Models
{
    public class Pedido
    {
        public int Id { get; }
        public Cliente Cliente { get; }
        public List<ItemPedido> Itens { get; }
        public DateTime Data { get; }
        public decimal ValorTotal { get; private set; }
        public decimal ValorComDesconto { get; private set; }

        private readonly IDesconto descontoStrategy;
        private readonly ILogger logger;

        public Pedido(int id, Cliente cliente, IDesconto descontoStrategy, ILogger logger)
        {
            Id = id;
            Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
            this.descontoStrategy = descontoStrategy ?? throw new ArgumentNullException(nameof(descontoStrategy));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Itens = new List<ItemPedido>();
            Data = DateTime.Now;
            ValorTotal = 0m;
            ValorComDesconto = 0m;
            logger.Log($"Pedido {Id} criado para o cliente {Cliente.Nome}.");
        }

        public void AdicionarItem(ItemPedido item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            Itens.Add(item);
            RecalcularValores();
            logger.Log($"Item adicionado ao pedido {Id}: {item.Produto.Nome} x {item.Quantidade}.");
        }

        private void RecalcularValores()
        {
            ValorTotal = Itens.Sum(i => i.CalcularTotal());
            var desconto = descontoStrategy.CalcularDesconto(this);
            ValorComDesconto = ValorTotal - desconto;
        }
    }
}
