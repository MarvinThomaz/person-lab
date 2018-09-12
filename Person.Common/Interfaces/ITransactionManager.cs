using System;
using System.Data;

namespace Person.Common.Interfaces
{
    public interface ITransactionManager : IDisposable
    {
        IDisposable Begin();
        void Commit();
        void Rollback();
        IDbTransaction GetCurrentTransaction();
    }
}