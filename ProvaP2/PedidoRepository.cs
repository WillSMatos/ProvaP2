using System.Collections.Generic;
using LojaVirtual.Models;

namespace LojaVirtual.Services
{
    public interface IPedidoRepository
    {
        void Adicionar(Pedido pedido);
        IEnumerable<Pedido> ObterTodos();
    }

    public class PedidoRepository : IPedidoRepository
    {
        private readonly List<Pedido> pedidos = new List<Pedido>();

        public void Adicionar(Pedido pedido)
        {
            pedidos.Add(pedido);
        }

        public IEnumerable<Pedido> ObterTodos()
        {
            return pedidos;
        }
    }
}
