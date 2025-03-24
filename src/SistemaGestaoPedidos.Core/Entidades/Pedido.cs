using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoPedidos.Core.Entidades
{
	public class Pedido
	{
		public Guid Id { get; private set; }
		public Cliente Cliente { get; private set; }
		public List<ItemPedido> Itens { get; private set; }
		public StatusPedido Status { get; private set; }

		public Pedido(Cliente cliente)
		{
			Id = Guid.NewGuid();
			Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
			Itens = new List<ItemPedido>();
			Status = StatusPedido.Pendente;
		}

		public void AdicionarItem(ItemPedido item)
		{
			if (Status == StatusPedido.Confirmado)
				throw new InvalidOperationException("Não é possível adicionar itens a um pedido já confirmado.");

			if (item.Quantidade <= 0)
				throw new ArgumentException("A quantidade do item deve ser maior que zero.");

			Itens.Add(item);
		}

		public void ConfirmarPedido()
		{
			if (!Itens.Any())
				throw new InvalidOperationException("O pedido deve ter pelo menos um item.");

			Status = StatusPedido.Confirmado;
		}

		public void CancelarPedido()
		{
			if (Status == StatusPedido.Confirmado)
				throw new InvalidOperationException("Não é possível cancelar um pedido já confirmado.");

			Status = StatusPedido.Cancelado;
		}

		// Correção na propriedade ValorTotal
		public decimal ValorTotal => Itens.Sum(item => item.PrecoUnitario * item.Quantidade);
	}

	public enum StatusPedido
	{
		Pendente,
		Confirmado,
		Enviado,
		Cancelado,
		Entregue
	}
}
