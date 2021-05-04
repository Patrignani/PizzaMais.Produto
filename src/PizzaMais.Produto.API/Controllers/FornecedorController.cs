using Microsoft.AspNetCore.Mvc;
using PizzaMais.Produto.Communs.DTOs;
using PizzaMais.Produto.Communs.Filtros;
using PizzaMais.Produto.Communs.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace PizzaMais.Produto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _service;

        public FornecedorController(IFornecedorService service) 
        {
            _service = service;
        }

        [HttpGet("LitarSimplificado")]
        public async Task<IActionResult> LitarSimplificadoAsync([FromQuery] FornecedorFiltro filtro) => Ok(await _service.LitarSimplificadoAsync(filtro));

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] FornecedorFiltro filtro) => Ok(await _service.ListarAsync(filtro));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id) => Ok(await _service.ObterPorIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] FornecedorInserir value) => Ok(await _service.InserirAsync(value));
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FornecedorAtualizar value)
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
    }
}
