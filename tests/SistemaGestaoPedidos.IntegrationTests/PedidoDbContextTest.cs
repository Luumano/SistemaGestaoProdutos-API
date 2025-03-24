using Microsoft.EntityFrameworkCore;
using SistemaGestaoPedidos.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoPedidos.IntegrationTests
{
	public class PedidoDbContextTest : DbContext
	{
		public PedidoDbContextTest(DbContextOptions<PedidoDbContextTest> options) : base(options) { }

		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Pedido> Pedidos { get; set; }
	}
}
