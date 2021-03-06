using Npgsql;
using PizzaMais.Produto.Communs.Interfaces;
using PizzaMais.Produto.Communs.Interfaces.Repository;
using PizzaMais.Produto.Core.Repository;
using System.Data;

namespace PizzaMais.Produto.Core
{
    internal class UnitOfWork : IUnitOfWork
    {
        IDbConnection _connection = null;
        IDbTransaction _transaction = null;

        private IFornecedorRepository _fornecedorRepository = null;
        private IProdutoRevendaRepository _produtoRevendaRepository = null;
        public UnitOfWork(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public IFornecedorRepository FornecedorRepository => _fornecedorRepository != null ? _fornecedorRepository : _fornecedorRepository = new FornecedorRepository(_connection, _transaction);
        public IProdutoRevendaRepository ProdutoRevendaRepository => _produtoRevendaRepository != null ? _produtoRevendaRepository : _produtoRevendaRepository = new ProdutoRevendaRepository(_connection, _transaction);
        public void Begin()
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();

            if (_transaction != null)
                _transaction.Dispose();
            _transaction = null;
        }
    }
}
