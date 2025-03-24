using SistemaGestaoPedidos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoPedidos.Tests.Entidades
{
	public class ItemPedidoTests
	{
		[Fact]
		public void ItemPedido_DeveCalcularValorTotalCorretamente()
		{
			// Arrange
			var item = new ItemPedido("Produto X", 20m, 3);

			// Act
			var valorTotal = item.ValorTotal;

			// Assert
			Assert.Equal(60m, valorTotal);
		}

		[Fact]
		public void ItemPedido_DeveTerIdUnico()
		{
			// Arrange
			var item1 = new ItemPedido("Produto A", 10m, 1);
			var item2 = new ItemPedido("Produto B", 15m, 1);

			// Act & Assert
			Assert.NotEqual(item1.Id, item2.Id);
		}
	}
}
