using System;
using System.Collections.Generic;
using LojaVirtual.Models;
using LojaVirtual.Services;
using LojaVirtual.Discounts;
using LojaVirtual.Logging;
using LojaVirtual.Reports;

namespace LojaVirtual
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();

            // Cadastro fixo de produtos
            var produtos = new List<Produto>()
            {
                new Produto(1, "Smartphone", 2500m, "Eletrônicos"),
                new Produto(2, "Camiseta", 100m, "Roupas"),
                new Produto(3, "Notebook", 3500m, "Eletrônicos"),
                new Produto(4, "Tênis", 300m, "Calçados"),
            };

            // Cadastro fixo de clientes
            var clientes = new List<Cliente>()
            {
                new Cliente(1, "Alice", "alice@email.com", "123.456.789-00"),
                new Cliente(2, "Bob", "bob@email.com", "987.654.321-00"),
            };

            // Criar fábrica de pedidos
            var pedidoFactory = new PedidoFactory(logger);
            var pedidoRepository = new PedidoRepository();

            // Criar pedidos com estratégias de desconto diferentes

            // Pedido 1: desconto por categoria Eletrônicos 10%
            var descontoEletronicos = new DescontoPorCategoria("Eletrônicos", 0.10m);
            var pedido1 = pedidoFactory.CriarPedido(clientes[0], descontoEletronicos);
            pedido1.AdicionarItem(new ItemPedido(produtos[0], 1)); // Smartphone
            pedido1.AdicionarItem(new ItemPedido(produtos[2], 1)); // Notebook
            pedidoRepository.Adicionar(pedido1);

            // Pedido 2: desconto por quantidade >= 3 itens 5%
            var descontoQuantidade = new DescontoPorQuantidade(3, 0.05m);
            var pedido2 = pedidoFactory.CriarPedido(clientes[1], descontoQuantidade);
            pedido2.AdicionarItem(new ItemPedido(produtos[1], 2)); // 2x Camiseta
            pedido2.AdicionarItem(new ItemPedido(produtos[3], 1)); // 1x Tênis
            pedidoRepository.Adicionar(pedido2);

            // Exibir relatório
            var relatorio = new RelatorioPedidos(pedidoRepository);
            relatorio.ExibirRelatorio();

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
