using System.IO;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TrackSampleStart.Repository;

public class RepositoryInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        string File = Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName,
                "talks.txt");
        container.Register(Component.For<IGetTalkRepository>().UsingFactoryMethod(x => new GetTalkRepository(File)));

    }
}