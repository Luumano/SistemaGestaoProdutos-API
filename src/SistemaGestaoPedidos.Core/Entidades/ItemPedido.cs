using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoPedidos.Core.Entidades
{
		public class ItemPedido
		{
			public Guid Id { get; private set; }
			public string Nome { get; private set; }
			public decimal PrecoUnitario { get; private set; }
			public int Quantidade { get; private set; }

			public ItemPedido(string nome, decimal precoUnitario, int quantidade)
			{
				if (quantidade <= 0)
					throw new ArgumentException("A quantidade deve ser maior que zero.");

				Id = Guid.NewGuid();
				Nome = nome;
				PrecoUnitario = precoUnitario;
				Quantidade = quantidade;
			}

			public decimal ValorTotal => PrecoUnitario * Quantidade;
	}
}
