using Dapper;
using PizzaMais.Produto.Communs.DTOs;
using PizzaMais.Produto.Communs.Filtros;
using PizzaMais.Produto.Communs.Interfaces.Repository;
using PizzaMais.Produto.Communs.Model;
using PizzaMais.Produto.Core.SqlCommands;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PizzaMais.Produto.Core.Repository
{
    internal class ProdutoRevendaRepository: Base.Base, IProdutoRevendaRepository
    {
        public ProdutoRevendaRepository(IDbConnection con, IDbTransaction tran) : base(con, tran)
        {

        }

        public async Task<int> InserirAsync(ProdutoRevenda model) =>
       await _connection.ExecuteScalarAsync<int>(ProdutoRevendaScript.Inserir(), model, transaction: _transaction).ConfigureAwait(false);

        public async Task AtualizarAsync(ProdutoRevenda model) =>
           await _connection.ExecuteAsync(ProdutoRevendaScript.Update(), model, transaction: _transaction).ConfigureAwait(false);

        public async Task<ProdutoRevendaObter> ObterAsync(int id) =>
           await _connection.QueryFirstOrDefaultAsync<ProdutoRevendaObter>(ProdutoRevendaScript.ObterPorId(), new { Id = id }, transaction: _transaction).ConfigureAwait(false);

        public async Task DeletarAsync(int id) =>
           await _connection.ExecuteAsync(ProdutoRevendaScript.Delete(), new { Id = id }).ConfigureAwait(false);

        public async Task<IEnumerable<ProdutoRevendaObter>> LitarAsync(ProdutoRevendaFiltro filtro) =>
            await _connection.QueryAsync<ProdutoRevendaObter>(ProdutoRevendaScript.Consulta(filtro), filtro, transaction: _transaction).ConfigureAwait(false);
    }
}
