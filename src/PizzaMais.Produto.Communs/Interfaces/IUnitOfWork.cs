using PizzaMais.Produto.Communs.Interfaces.Repository;
using System;

namespace PizzaMais.Produto.Communs.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFornecedorRepository FornecedorRepository { get; }

        void Begin();
        void Rollback();
        void Commit();
    }
}
