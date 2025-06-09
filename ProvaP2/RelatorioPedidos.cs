using System;
using LojaVirtual.Services;

namespace LojaVirtual.Reports
{
    public class RelatorioPedidos
    {
        private readonly IPedidoRepository repository;

        public RelatorioPedidos(IPedidoRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void ExibirRelatorio()
        {
            Console.WriteLine("===== Relatório de Pedidos =====");
            foreach (var pedido in repository.ObterTodos())
            {
                Console.WriteLine($"Pedido ID: {pedido.Id}");
                Console.WriteLine($"Cliente: {pedido.Cliente.Nome} ({pedido.Cliente.Email})");
                Console.WriteLine($"Data: {pedido.Data}");
                Console.WriteLine("Itens:");
                foreach (var item in pedido.Itens)
                {
                    Console.WriteLine($" - {item.Produto.Nome} | Categoria: {item.Produto.Categoria} | Preço: {item.Produto.Preco:C} | Quantidade: {item.Quantidade} | Total: {item.CalcularTotal():C}");
                }
                Console.WriteLine($"Valor Total: {pedido.ValorTotal:C}");
                Console.WriteLine($"Valor com Desconto: {pedido.ValorComDesconto:C}");
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
