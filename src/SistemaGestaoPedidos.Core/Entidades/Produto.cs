using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoPedidos.Core.Entidades
{
	public class Produto
	{
		public Guid Id { get; private set; }
		public string Nome { get; private set; }
		public string Descricao { get; private set; }
		public decimal Preco { get; private set; }
		public int Estoque { get; set; }

		public Produto(string nome, string descricao, decimal preco, int estoque)
		{
			if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("O nome do produto é obrigatório.");
			if (preco <= 0) throw new ArgumentException("O preço do produto deve ser maior que zero.");
			if (estoque < 0) throw new ArgumentException("O estoque não pode ser negativo.");

			Id = Guid.NewGuid();
			Nome = nome;
			Descricao = descricao;
			Preco = preco;
			Estoque = estoque;
		}


		public void AtualizarEstoque(int quantidade)
		{
			if (Estoque + quantidade < 0)
			{
				throw new InvalidOperationException("Estoque insuficiente.");
			}
			Estoque += quantidade;
		}

		public class AtualizarEstoqueDto
		{
			public int Quantidade { get; set; }
		}
	}
}
