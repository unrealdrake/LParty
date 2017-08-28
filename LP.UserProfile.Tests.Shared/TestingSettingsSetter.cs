using LP.UserProfile.ApplicationService.Write.RegisterNewProfile;
using LP.UserProfile.Tests.Shared.SampleData;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;
using Shared.Infrasctructure.EntityFramework;

namespace LP.UserProfile.Tests.Shared
{
    public abstract class BaseTestClass
    {
        private static IMediator _mediator;

        protected virtual void Init(TestContext testContext)
        {
            SetTestSettings();
            _mediator = MediatorBuilder.BuildMediator();
            FillDatabaseWithTestData();
        }

        protected static void SetTestSettings()
        {
            ResolverRoot.Settings.ConnectionString = ConnectionStringFactory.Create(useTestConnectionString: true);
        }

        private static void FillDatabaseWithTestData()
        {
            foreach (var profile in NewProfileRegisters.Profiles)
            {
                _mediator.Send(new RegisterNewProfileCommand(profile)).ConfigureAwait(false);
            }
        }

        [TestCleanup]
        public void CleanDatabase()
        {
            
        }
    }
}
