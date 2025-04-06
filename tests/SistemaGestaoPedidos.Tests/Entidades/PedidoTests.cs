using SistemaGestaoPedidos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoPedidos.Tests.Entidades
{
	public class PedidoTests
	{
		[Fact]
		public void StatusPendente()
		{
			var cliente = new Cliente("João Silva", "joao@email.com");
			var pedido = new Pedido(cliente);

			Assert.Equal(StatusPedido.Pendente, pedido.Status);
		}

		[Fact]
		public void ConfirmadoSemItens()
		{
			var cliente = new Cliente("Maria Souza", "maria@email.com");
			var pedido = new Pedido(cliente);

			var exception = Assert.Throws<InvalidOperationException>(() => pedido.ConfirmarPedido());
			Assert.Equal("O pedido deve ter pelo menos um item.", exception.Message);
		}

		[Fact]
		public void CalcularValorTotal()
		{
			var cliente = new Cliente("Carlos Mendes", "carlos@email.com");
			var pedido = new Pedido(cliente);
			pedido.AdicionarItem(new ItemPedido("Fone Ouvido", 10m, 2));
			pedido.AdicionarItem(new ItemPedido("Mouse", 10m, 1));

			var valorTotal = pedido.ValorTotal;

			Assert.Equal(30m, valorTotal);
		}

		[Fact]
		public void StatusConfirmado()
		{
			var cliente = new Cliente("Ana Clara", "ana@email.com");
			var pedido = new Pedido(cliente);
			pedido.AdicionarItem(new ItemPedido("Teclado", 50m, 1));

			pedido.ConfirmarPedido();

			Assert.Equal(StatusPedido.Confirmado, pedido.Status);
		}

		[Fact]
		public void ItemComQuantidadeNegativa()
		{
			var cliente = new Cliente("Roberto Dias", "roberto@email.com");
			var pedido = new Pedido(cliente);

			var exception = Assert.Throws<ArgumentException>(() =>pedido.AdicionarItem(new ItemPedido("Monitor", 500m, -1)));

			Assert.Equal("A quantidade deve ser maior que zero.", exception.Message);
		}

		[Fact]
		public void AdicionarVariosItens()
		{
			var cliente = new Cliente("Fernanda Lima", "fernanda@email.com");
			var pedido = new Pedido(cliente);
			pedido.AdicionarItem(new ItemPedido("Mouse", 40m, 1));
			pedido.AdicionarItem(new ItemPedido("Teclado", 60m, 1));
			pedido.AdicionarItem(new ItemPedido("Headset", 120m, 1));

			Assert.Equal(3, pedido.Itens.Count);
		}

		[Fact]
		public void Cancelado()
		{
			var cliente = new Cliente("Paulo Henrique", "paulo@email.com");
			var pedido = new Pedido(cliente);
			pedido.AdicionarItem(new ItemPedido("Impressora", 700m, 1));
			pedido.ConfirmarPedido();

			var exception = Assert.Throws<InvalidOperationException>(() => pedido.CancelarPedido());
			Assert.Equal("Não é possível cancelar um pedido já confirmado.", exception.Message);
		}

		[Fact]
		public void StatusCancelado()
		{
			var cliente = new Cliente("Gabriela Nunes", "gabriela@email.com");
			var pedido = new Pedido(cliente);
			pedido.AdicionarItem(new ItemPedido("Cadeira Gamer", 900m, 1));

			pedido.CancelarPedido();

			Assert.Equal(StatusPedido.Cancelado, pedido.Status);
		}

		[Fact]
		public void PermitirAdicionarItem() // Não permitir adicionar item após a confirmação
		{
			var cliente = new Cliente("Julio Cesar", "julio@email.com");
			var pedido = new Pedido(cliente);
			pedido.AdicionarItem(new ItemPedido("Mesa Escritório", 400m, 1));
			pedido.ConfirmarPedido();

			var exception = Assert.Throws<InvalidOperationException>(() =>
				pedido.AdicionarItem(new ItemPedido("Luminária", 50m, 1))
			);

			Assert.Equal("Não é possível adicionar itens a um pedido já confirmado.", exception.Message);
		}
	}
}

