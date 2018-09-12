using System;
using System.Data;
using Person.Common.Interfaces;

namespace Person.Infrastructure.Transaction
{
    public class TransactionManager : ITransactionManager
    {
        private readonly IDbConnection _connection;

        private IDbTransaction _transaction;

        public TransactionManager(IDbConnection connection)
        {
            _connection = connection;
        }

        public IDisposable Begin()
        {
            _transaction = _connection.BeginTransaction();

            return _transaction;
        }

        public void Commit()
        {
            _transaction?.Commit();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }

        public IDbTransaction GetCurrentTransaction()
        {
            return _transaction;
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }
    }
}