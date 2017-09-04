using System;
using System.Collections.Generic;

namespace Shared.Infrasctructure.BusinessTransaction
{
    public sealed class TransactionCompleteHandler
    {
        private readonly List<Action> _abortedActions = new List<Action>();

        public TransactionCompleteHandler(CommitableBusinessTransaction transaction)
        {
            transaction.TransactionCompleted += HandleComplete;
        }

        public event Action Aborted
        {
            add => _abortedActions.Add(value);
            remove => _abortedActions.Remove(value);
        }

        private void HandleComplete(object sender, EventArgs e)
        {
            if ((sender as CommitableBusinessTransaction)?.Status == TransactionStatus.Aborted)
            {
                _abortedActions.Reverse();
                _abortedActions.ForEach(PerformIsolatedAction);
            }
            _abortedActions.Clear();
        }

        private static void PerformIsolatedAction(Action isolatedAction)
        {
            try
            {
                isolatedAction();
            }
            catch (Exception)
            {
                //Logger.ErrorFormat("Isolated action failed", ex);
            }
        }
    }
}
