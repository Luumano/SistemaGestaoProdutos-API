namespace SistemaGestaoPedidos.Core.Entidades
{
	public class Pagamento
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid PedidoId { get; set; }
		public decimal Valor { get; set; }
		public string MetodoPagamento { get; set; } = string.Empty; // Ex: "Cartão de Crédito"
		public string Status { get; set; } = "Pendente"; // "Aprovado", "Recusado"
		public DateTime DataPagamento { get; set; }

		public void AprovarPagamento()
		{
			Status = "Aprovado";
			DataPagamento = DateTime.Now;
		}

		public void RecusarPagamento()
		{
			Status = "Recusado";
			DataPagamento = DateTime.Now;
		}
	}
}
