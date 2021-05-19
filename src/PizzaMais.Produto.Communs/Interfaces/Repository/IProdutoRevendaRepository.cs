using PizzaMais.Produto.Communs.DTOs;
using PizzaMais.Produto.Communs.Filtros;
using PizzaMais.Produto.Communs.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaMais.Produto.Communs.Interfaces.Repository
{
    public interface IProdutoRevendaRepository
    {
        Task<int> InserirAsync(ProdutoRevenda model);
        Task<ProdutoRevendaObter> ObterAsync(int id);
        Task AtualizarAsync(ProdutoRevenda model);
        Task DeletarAsync(int id);
        Task<IEnumerable<ProdutoRevendaObter>> LitarAsync(ProdutoRevendaFiltro filtro);
    }
}
