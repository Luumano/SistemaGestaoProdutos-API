using Microsoft.AspNetCore.Mvc;
using SistemaGestaoPedidos.Core.Entidades;

namespace SistemaGestaoPedidos.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PagamentoController : ControllerBase
	{
		private static readonly List<Pagamento> Pagamentos = new();

		[HttpPost]
		public IActionResult RealizarPagamento([FromBody] Pagamento pagamento)
		{
			// Simulação de processamento do pagamento
			if (pagamento.Valor > 0)
			{
				pagamento.AprovarPagamento();
			}
			else
			{
				pagamento.RecusarPagamento();
			}

			Pagamentos.Add(pagamento);
			return Ok(pagamento);
		}

		[HttpGet]
		public IActionResult ObterPagamentos()
		{
			return Ok(Pagamentos);
		}

		[HttpGet("{id}")]
		public IActionResult ObterPagamentoPorId(Guid id)
		{
			var pagamento = Pagamentos.Find(p => p.Id == id);
			if (pagamento == null)
			{
				return NotFound("Pagamento não encontrado.");
			}
			return Ok(pagamento);
		}
	}
}
