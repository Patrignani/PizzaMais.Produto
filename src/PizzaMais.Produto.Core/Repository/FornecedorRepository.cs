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
    internal class FornecedorRepository: Base.Base, IFornecedorRepository
    {
        public FornecedorRepository(IDbConnection con, IDbTransaction tran) : base(con, tran)
        {

        }

        public async Task<int> InserirAsync(Fornecedor model) =>
           await _connection.ExecuteScalarAsync<int>(FornecedorSql.Inserir(), model, transaction: _transaction).ConfigureAwait(false);

        public async Task AtualizarAsync(Fornecedor model) =>
            await _connection.ExecuteAsync(FornecedorSql.Update(), model, transaction: _transaction).ConfigureAwait(false);

        public async Task<IEnumerable<FornecedorObter>> LitarAsync(FornecedorFiltro filtro) =>
            await _connection.QueryAsync<FornecedorObter>(FornecedorSql.Consulta(filtro), filtro, transaction: _transaction).ConfigureAwait(false);

        public async Task<FornecedorObter> ObterAsync(int id) =>
            await _connection.QueryFirstOrDefaultAsync<FornecedorObter>(FornecedorSql.ObterPorId(), new { Id = id }, transaction: _transaction).ConfigureAwait(false);

        public async Task DeletarAsync(int id) =>
            await _connection.ExecuteAsync(FornecedorSql.Delete(), new { Id = id }).ConfigureAwait(false);

        public async Task<IEnumerable<FornecedorSimplificado>> LitarSimplificadoAsync(FornecedorFiltro filtro) =>
            await _connection.QueryAsync<FornecedorSimplificado>(FornecedorSql.ConsultaSimplificada(filtro), filtro).ConfigureAwait(false);
    }
}
