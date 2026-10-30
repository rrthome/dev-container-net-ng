public class Pedido
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public StatusPedido Status { get; set; }
    public decimal DescontoPercentual { get; set; }
    public decimal Total { get; set; }

    public List<ItemPedido> Itens { get; set; } = new();

    public void CalcularTotal()
    {
        var subtotal = Itens.Sum(x => x.Preco);
        Total = subtotal - (subtotal - DescontoPercentual);
    }
}
