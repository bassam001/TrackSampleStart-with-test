using System;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;

namespace TrackSampleStart.Tests
{
   public class SharedContainerFixture 
    {
        public IWindsorContainer SharedWindsorContainer { get; }

        public SharedContainerFixture()
        {
            SharedWindsorContainer = new WindsorContainer();
            SharedWindsorContainer.Kernel.Resolver.AddSubResolver(new CollectionResolver(SharedWindsorContainer.Kernel));
            SharedWindsorContainer.Install(new ServicesInstaller());
            SharedWindsorContainer.Install(new RepositoryInstaller());
        }
     
    }
}