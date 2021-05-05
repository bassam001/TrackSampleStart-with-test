using System;
using Castle.Windsor;

namespace TrackSampleStart.Tests
{
   public class SharedContainerFixture :IDisposable
    {
        public IWindsorContainer SharedWindsorContainer { get; private set; }

        public SharedContainerFixture()
        {
            SharedWindsorContainer = new WindsorContainer();
            SharedWindsorContainer.Install(new ServicesInstaller());
            SharedWindsorContainer.Install(new RepositoryInstaller());

        }
        public void Dispose()
        {
          
        }
    }
}