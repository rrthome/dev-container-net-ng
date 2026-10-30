using Microsoft.EntityFrameworkCore;

public class ExclusaoPedido : IExclusaoPedido
{
    private AppDbContext _dbContext;

    public ExclusaoPedido(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> ExcluirPedido(Guid id)
    {
        var pedido = _dbContext.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
        if (pedido is null) 
            throw new Exception("Pedido não encontrado");

        _dbContext.Remove(pedido);
        return await _dbContext.SaveChangesAsync();
    }
}