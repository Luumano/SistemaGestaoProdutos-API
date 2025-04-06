using System;
using System.Collections.Generic;
using FluentAssertions;
using SistemaGestaoPedidos.Core.Entidades;
using TechTalk.SpecFlow;

namespace SistemaGestaoPedidos.AcceptanceTests.Features.Steps
{
	[Binding]
	public class PedidoSteps
	{
		private Cliente _cliente = new Cliente("João Mateus", "mateusl@teste.com");
		private Pedido _pedido = new Pedido(new Cliente("Lucios Valter", "lucioll@teste.com"));

		private decimal _valorTotalCalculado;

		[Given(@"que um cliente chamado ""(.*)"" deseja fazer um pedido")]
		public void FazerUmPedido(string nome)
		{
			_cliente = new Cliente(nome, "email@teste.com");
			_pedido = new Pedido(_cliente);
		}

		[When(@"ele adiciona os seguintes itens ao pedido:")]
		public void ItensAoPedido(Table table)
		{
			foreach (var row in table.Rows)
			{
				var nome = row["Nome"];
				var preco = decimal.Parse(row["Preço"]);
				var quantidade = int.Parse(row["Quantidade"]);

				var item = new ItemPedido(nome, preco, quantidade);
				_pedido.AdicionarItem(item);
			}
		}

		[When(@"ele confirma o pedido")]
		public void ConfirmaOPedido()
		{
			_pedido.ConfirmarPedido();
		}

		[Then(@"o pedido deve ter o status ""(.*)""")]
		public void Status(string statusEsperado)
		{
			var statusReal = _pedido.Status.ToString();
			statusReal.Should().Be(statusEsperado);
		}

		[Then(@"o valor total do pedido deve ser (.*)")]
		public void ValorTotalPedido(decimal valorEsperado)
		{
			_valorTotalCalculado = _pedido.ValorTotal;
			_valorTotalCalculado.Should().Be(valorEsperado);
		}
	}
}
