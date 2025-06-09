using System;
using LojaVirtual.Models;
using LojaVirtual.Discounts;
using LojaVirtual.Logging;

namespace LojaVirtual.Services
{
    public interface IPedidoFactory
    {
        Pedido CriarPedido(Cliente cliente, IDesconto descontoStrategy);
    }

    public class PedidoFactory : IPedidoFactory
    {
        private static int ultimoId = 0;
        private readonly ILogger logger;

        public PedidoFactory(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Pedido CriarPedido(Cliente cliente, IDesconto descontoStrategy)
        {
            ultimoId++;
            return new Pedido(ultimoId, cliente, descontoStrategy, logger);
        }
    }
}
