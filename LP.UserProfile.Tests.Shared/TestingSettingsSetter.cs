using LP.UserProfile.ApplicationService.Write.RegisterNewProfile;
using LP.UserProfile.Domain.User_Area.Repositories;
using LP.UserProfile.Tests.Shared.SampleData;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;
using Shared.Infrasctructure.EntityFramework;

namespace LP.UserProfile.Tests.Shared
{
    public abstract class BaseTestClass
    {
        protected static IMediator Mediator;
        private static IWriteUserProfileRepository _writeUserProfileRepository;

        protected static void Init(TestContext testContext)
        {
            SetTestSettings();
            Mediator = MediatorBuilder.BuildMediator();
            _writeUserProfileRepository = ResolverRoot.Resolve<IWriteUserProfileRepository>();
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
                Mediator.Send(new RegisterNewProfileCommand(profile)).ConfigureAwait(false);
            }
        }

        [TestCleanup]
        public void CleanDatabase()
        {
            _writeUserProfileRepository.ClearAllAsync().Wait();
        }
    }
}
