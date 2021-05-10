using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using TrackSampleStart.Domain;
using TrackSampleStart.Parsers;
using Xunit;

namespace TrackSampleStart.Tests
{
    public abstract class TestBase
    {
        protected IWindsorContainer _container;

        protected TalkParser _talkParser;
        protected Talk _talk;
        protected Talk _lightningTalk;

        public TestBase()
        {
            _container = new WindsorContainer();
            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel));
            _container.Install(new ServicesInstaller());
            _container.Install(new RepositoryInstaller());
            _container.ResolveAll<IParser>();

            _talkParser = _container.Resolve<TalkParser>();
            _lightningTalk = new Talk { Title = "Rails for Python Developers lightning" };
            _talk = new Talk { Title = "Lua for the Masses 30min" };
        }
    }
}
