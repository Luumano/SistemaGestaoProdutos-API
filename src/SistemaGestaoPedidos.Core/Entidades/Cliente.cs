using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoPedidos.Core.Entidades
{
	public class Cliente
	{
		public Guid Id { get; private set; }
		public string Nome { get; private set; }
		public string Email { get; private set; }

		public Cliente(string nome, string email)
		{
			Id = Guid.NewGuid();
			Nome = nome;
			Email = email;
		}
	}
}
