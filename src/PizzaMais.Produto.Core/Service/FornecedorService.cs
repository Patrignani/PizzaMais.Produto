using PizzaMais.Produto.Communs.DTOs;
using PizzaMais.Produto.Communs.Filtros;
using PizzaMais.Produto.Communs.Interfaces;
using PizzaMais.Produto.Communs.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaMais.Produto.Core.Service
{
    internal class FornecedorService : IFornecedorService
    {
        private readonly IUnitOfWork _uow;

        public FornecedorService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<FornecedorObter> InserirAsync(FornecedorInserir model)
        {
            var fornecedor = model.GerarFornecedor();

            fornecedor.Id = await _uow.FornecedorRepository.InserirAsync(fornecedor);

            return new FornecedorObter(fornecedor);
        }

        public async Task<FornecedorObter> AtualizarAsync(FornecedorAtualizar model)
        {
            var fornecedor = model.GerarFornecedor();

            await _uow.FornecedorRepository.AtualizarAsync(fornecedor);

            return new FornecedorObter(fornecedor);
        }

        public async Task DeletarAsync(int id) => await _uow.FornecedorRepository.DeletarAsync(id);

        public async Task<FornecedorObter> ObterPorIdAsync(int id) => await _uow.FornecedorRepository.ObterAsync(id);

        public async Task<IEnumerable<FornecedorObter>> ListarAsync(FornecedorFiltro filtro) =>
            await _uow.FornecedorRepository.LitarAsync(filtro);

        public async Task<IEnumerable<FornecedorSimplificado>> LitarSimplificadoAsync(FornecedorFiltro filtro) =>
            await _uow.FornecedorRepository.LitarSimplificadoAsync(filtro);

    }
}
