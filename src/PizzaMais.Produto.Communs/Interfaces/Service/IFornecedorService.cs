using PizzaMais.Produto.Communs.DTOs;
using PizzaMais.Produto.Communs.Filtros;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaMais.Produto.Communs.Interfaces.Service
{
    public interface IFornecedorService
    {
        Task<FornecedorObter> InserirAsync(FornecedorInserir model);
        Task<FornecedorObter> AtualizarAsync(FornecedorAtualizar model);
        Task DeletarAsync(int id);
        Task<FornecedorObter> ObterPorIdAsync(int id);
        Task<IEnumerable<FornecedorObter>> ListarAsync(FornecedorFiltro filtro);
        Task<IEnumerable<FornecedorSimplificado>> LitarSimplificadoAsync(FornecedorFiltro filtro);
    }
}
