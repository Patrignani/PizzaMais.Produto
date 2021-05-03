using System;

namespace PizzaMais.Produto.Communs.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();
        void Rollback();
        void Commit();
    }
}
