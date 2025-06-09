using LojaVirtual.Models;

namespace LojaVirtual.Discounts
{
    public interface IDesconto
    {
        decimal CalcularDesconto(Pedido pedido);
    }
}
