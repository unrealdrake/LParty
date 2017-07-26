using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Infrasctructure.BusinessTransaction;

namespace Shared.Infrasctructure.Tests
{
    [TestClass]
    public class BusinessTransactionTests
    {
        [TestMethod]
        public void AbortedActionMustBePerformedIfExceptionOccurs()
        {
            int signalValue = 1;
            try
            {
                using (var transaction = new CommitableBusinessTransaction())
                {
                    var transactionHandler = new TransactionCompleteHandler(transaction);
                    transactionHandler.Aborted += () => signalValue = 0;

                    throw new OperationCanceledException();
                }
            }
            catch (OperationCanceledException e)
            {
            }

            Assert.AreEqual(signalValue, 0);
        }

        [TestMethod]
        public void AbortedActionMustBePerformedNotCommited()
        {
            int signalValue = 1;
            using (var transaction = new CommitableBusinessTransaction())
            {
                var transactionHandler = new TransactionCompleteHandler(transaction);
                transactionHandler.Aborted += () => signalValue = 0;


            }

            Assert.AreEqual(signalValue, 0);
        }

        [TestMethod]
        public void AbortedActionMustNotBePerformedCommited()
        {
            int signalValue = 1;
            using (var transaction = new CommitableBusinessTransaction())
            {
                var transactionHandler = new TransactionCompleteHandler(transaction);
                transactionHandler.Aborted += () => signalValue = 0;

                transaction.Commit();
            }

            Assert.AreEqual(signalValue, 1);
        }

        [TestMethod]
        public void AbortedStatusMustBeIfExceptionOccurs()
        {
            var transaction = new CommitableBusinessTransaction();
            try
            {
                using (transaction)
                {
                    throw new OperationCanceledException();
                }

            }
            catch (OperationCanceledException e)
            {
            }

            Assert.AreEqual(transaction.Status, TransactionStatus.Aborted);
        }

        [TestMethod]
        public void AbortedStatusMustBeIfNotCommited()
        {
            var transaction = new CommitableBusinessTransaction();
            using (transaction)
            {
            }

            Assert.AreEqual(transaction.Status, TransactionStatus.Aborted);
        }

        [TestMethod]
        public void CompletedStatusMustBeIfCommitedAndNoErrorsOccured()
        {
            var transaction = new CommitableBusinessTransaction();
            using (transaction)
            {
                transaction.Commit();
            }

            Assert.AreEqual(transaction.Status, TransactionStatus.Completed);
        }
    }
}
