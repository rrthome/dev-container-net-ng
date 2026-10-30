public interface IInclusaoPedido
{
    Task<Pedido> IncluirPedido(PedidoDto pedido);
}