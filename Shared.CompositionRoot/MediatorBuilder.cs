using LP.UserProfile.ApplicationService.Write.RegisterNewProfile;
using LP.UserProfile.Domain.User_Area.Events;
using MediatR;
using SharedKernel.DomainEvents;
using StructureMap;

namespace Shared.CompositionRoot
{
    public class MediatorBuilder
    {
        public static void RegisterDependenciesForMediator(ConfigurationExpression cfg)
        {
            cfg.Scan(scanner =>
            {
                scanner.AssemblyContainingType<RegisterNewProfileCommand>(); // Our assembly with requests & handlers
                scanner.AssemblyContainingType<UserProfileCreatedEvent>();

                scanner.ConnectImplementationsToTypesClosing(typeof(IHandles<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<>)); // Handlers with no response
                scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>)); // Handlers with a response
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<>)); // Async handlers with no response
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>)); // Async Handlers with a response
                scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));
            });
            cfg.For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => ctx.GetInstance);
            cfg.For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => ctx.GetAllInstances);
            cfg.For<IMediator>().Use<Mediator>();
        }

        public static IMediator BuildMediator()
        {
            var mediator = ResolverRoot.Resolve<IMediator>();
            return mediator;
        }
    }
}
