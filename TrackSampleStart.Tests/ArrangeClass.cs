using Castle.Windsor;
using TrackSampleStart.Domain;
using TrackSampleStart.Parsers;
using Xunit;

namespace TrackSampleStart.Tests
{
    public class ArrangeClass:IClassFixture<SharedContainerFixture>
    {
        protected IWindsorContainer _container;

        protected IParser _parser;
        protected Talk _talk;
        protected Talk _lightningTalk;

        public   ArrangeClass()
        {
            _container = new WindsorContainer();
            _container.Install(new ServicesInstaller());
            _parser = _container.Resolve<IParser>();
            _lightningTalk = new Talk { Title = "Rails for Python Developers lightning" };
            _talk = new Talk { Title = "Lua for the Masses 30min" };
        }
    }
}
