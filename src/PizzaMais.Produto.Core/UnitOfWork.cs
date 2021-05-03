using PizzaMais.Produto.Communs.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace PizzaMais.Produto.Core
{
    internal class UnitOfWork : IUnitOfWork
    {
        IDbConnection _connection = null;
        IDbTransaction _transaction = null;

        public UnitOfWork(SqlConnection connection)
        {
            _connection = connection;
        }

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
