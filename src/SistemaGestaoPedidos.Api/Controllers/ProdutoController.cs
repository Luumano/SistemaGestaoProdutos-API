using Microsoft.AspNetCore.Mvc;
using SistemaGestaoPedidos.Core.Entidades;
using static SistemaGestaoPedidos.Core.Entidades.Produto;


namespace SistemaGestaoPedidos.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProdutoController : ControllerBase
	{
		private static readonly List<Produto> Produtos = new();


		[HttpGet]
		public IActionResult ObterProdutos()
		{
			return Ok(Produtos);
		}

		[HttpGet("{id}")]
		public IActionResult ObterProdutoPorId(Guid id)
		{
			var produto = Produtos.Find(p => p.Id == id);
			if(produto == null)
			{
				return NotFound("Produto não encontrado.");
			}
			return Ok(produto);
		}

		[HttpPost]
		public IActionResult CriarProduto([FromBody] Produto produto)
		{
			Produtos.Add(produto);
			return CreatedAtAction(nameof(ObterProdutoPorId), new { id = produto.Id }, produto);
		}

		[HttpPut("{id}")]
		public IActionResult AtualizarEstoque(Guid id, [FromBody] AtualizarEstoqueDto dto)
		{
			var produto = Produtos.Find(p => p.Id == id);
			if (produto == null)
			{
				return NotFound("Produto não encontrado.");
			}
			produto.AtualizarEstoque(dto.Quantidade);
			return Ok(produto);
		}
		[HttpDelete("{id}")]
		public IActionResult DeletarProduto(Guid id)
		{
			var produto = Produtos.Find(p => p.Id == id);
			if (produto == null)
			{
				return NotFound("Produto não encontrado.");
			}

			Produtos.Remove(produto);
			return NoContent(); // Retorna 204 (sem conteúdo) para indicar que a operação foi bem-sucedida.
		}

	}
}
