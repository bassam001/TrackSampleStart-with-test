using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TrackSampleStart.DomainServices;
using TrackSampleStart.Parsers;

public class ServicesInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {

        container.Register(Component.For<IService>().ImplementedBy<Service>());
        container.Register(Component.For<ITrackManager>().UsingFactoryMethod(x => TrackManager.Instance));
       

        container.Register(
            Component.For<IParser>().ImplementedBy<MinuteParser>(),
            Component.For<IParser>().ImplementedBy<LightningParser>()
        );

        container.Register(Component.For<TalkManager>());
        container.Register(Component.For<TalkParser>());

    }
}