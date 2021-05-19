using PizzaMais.Produto.Communs.DTOs;
using PizzaMais.Produto.Communs.Filtros;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaMais.Produto.Communs.Interfaces.Service
{
    public interface IProdutoRevendaService
    {
        Task<ProdutoRevendaObter> InserirAsync(ProdutoRevendaInserir model);
        Task<ProdutoRevendaObter> ObterPorIdAsync(int id);
        Task<ProdutoRevendaObter> AtualizarAsync(ProdutoRevendaAtualizar model);
        Task DeletarAsync(int id);
        Task<IEnumerable<ProdutoRevendaObter>> ListarAsync(ProdutoRevendaFiltro filtro);
    }
}
