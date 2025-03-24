using SistemaGestaoPedidos.Core.Entidades;

namespace SistemaGestaoPedidos.IntegrationTests;

public class PedidoClienteTests
{
    [Fact]
    public void CriarPedido_DeveAssociarAoCliente_Corretamente()
    {
        // Arrange
        var cliente = new Cliente("João Kauê", "kaue@gmail.com");
        var pedido = new Pedido(cliente);

        // Act
        pedido.AdicionarItem(new ItemPedido("Teclado", 150m, 1));
        pedido.AdicionarItem(new ItemPedido("Mouse", 75m, 1));

        Assert.Equal(cliente.Id, pedido.Cliente.Id);
        Assert.Equal(2, pedido.Itens.Count);
        Assert.Equal(225m, pedido.ValorTotal);


    }
}
