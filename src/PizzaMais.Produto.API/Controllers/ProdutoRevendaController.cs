using Microsoft.AspNetCore.Mvc;
using PizzaMais.Produto.Communs.DTOs;
using PizzaMais.Produto.Communs.Filtros;
using PizzaMais.Produto.Communs.Interfaces.Service;
using System.Threading.Tasks;

namespace PizzaMais.Produto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoRevendaController : ControllerBase
    {
        private readonly IProdutoRevendaService _service;

        public ProdutoRevendaController(IProdutoRevendaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProdutoRevendaInserir value) => Ok(await _service.InserirAsync(value));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id) => Ok(await _service.ObterPorIdAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProdutoRevendaAtualizar value)
        {
            if (value.Id == id)
            {
                return Ok(await _service.AtualizarAsync(value));
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletarAsync(id);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] ProdutoRevendaFiltro filtro) => Ok(await _service.ListarAsync(filtro));
    }
}
