
public class InclusaoPedido : IInclusaoPedido
{
    private readonly AppDbContext _context;

    public InclusaoPedido(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public async Task<Pedido> IncluirPedido(PedidoDto pedido)
    {
        if (pedido.Itens == null || pedido.Itens.Count == 0)
            throw new Exception("O pedido deve ter ao menos 1 item.");

        var pedidoEntity = new Pedido
        {
            Id = Guid.NewGuid(),
            Data = new DateTime(),
            Status = StatusPedido.NoCarrinho,
            DescontoPercentual = pedido.DescontoPercentual,
            Itens = pedido.Itens.Select(i => new ItemPedido
            {
                Nome = i.Nome,
                Preco = i.Preco
            }).ToList()
        };

        pedidoEntity.CalcularTotal();

        _context.Pedidos.Add(pedidoEntity);
        await _context.SaveChangesAsync();

        return pedidoEntity;
    }
}