using PizzaMais.Produto.Communs.DTOs;
using PizzaMais.Produto.Communs.Filtros;
using PizzaMais.Produto.Communs.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaMais.Produto.Communs.Interfaces.Repository
{
    public interface IFornecedorRepository
    {
        Task<int> InserirAsync(Fornecedor model);
        Task AtualizarAsync(Fornecedor model);
        Task<IEnumerable<FornecedorObter>> LitarAsync(FornecedorFiltro filtro);
        Task<FornecedorObter> ObterAsync(int id);
        Task DeletarAsync(int id);
        Task<IEnumerable<FornecedorSimplificado>> LitarSimplificadoAsync(FornecedorFiltro filtro);
    }
}
