public interface IExclusaoPedido
{
    Task<int> ExcluirPedido(Guid id);
}