using PizzaMais.Produto.Communs.DTOs;
using PizzaMais.Produto.Communs.Filtros;
using PizzaMais.Produto.Communs.Interfaces;
using PizzaMais.Produto.Communs.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaMais.Produto.Core.Service
{
    internal class ProdutoRevendaService : IProdutoRevendaService
    {
        private readonly IUnitOfWork _uow;

        public ProdutoRevendaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ProdutoRevendaObter> InserirAsync(ProdutoRevendaInserir model)
        {
            var produtoRevenda = model.GerarProdutoRevenda(1);

            produtoRevenda.Id = await _uow.ProdutoRevendaRepository.InserirAsync(produtoRevenda);

            return new ProdutoRevendaObter(produtoRevenda, model.FornecedorNome);
        }

        public async Task<ProdutoRevendaObter> ObterPorIdAsync(int id)  => await _uow.ProdutoRevendaRepository.ObterAsync(id);

        public async Task<ProdutoRevendaObter> AtualizarAsync(ProdutoRevendaAtualizar model)
        {
            var produtoRevenda = model.GerarProdutoRevenda(1);

            await _uow.ProdutoRevendaRepository.AtualizarAsync(produtoRevenda);

            return new ProdutoRevendaObter(produtoRevenda, model.FornecedorNome);
        }
        public async Task DeletarAsync(int id) => await _uow.ProdutoRevendaRepository.DeletarAsync(id);

        public async Task<IEnumerable<ProdutoRevendaObter>> ListarAsync(ProdutoRevendaFiltro filtro) => 
            await _uow.ProdutoRevendaRepository.LitarAsync(filtro);

    }
}
