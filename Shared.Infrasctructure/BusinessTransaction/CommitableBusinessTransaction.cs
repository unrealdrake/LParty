using System;

namespace Shared.Infrasctructure.BusinessTransaction
{
    public sealed class CommitableBusinessTransaction : IDisposable
    {
        private TransactionStatus _status = TransactionStatus.Aborted;
        public TransactionStatus Status => _status;

        public event EventHandler TransactionCompleted;

        public void Commit()
        {
            _status = TransactionStatus.Completed;
        }

        public void Dispose()
        {
            TransactionCompleted?.Invoke(this, null);
        }
    }
}
