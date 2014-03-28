using app.utility.container;
using app.utility.container.basic;

namespace app.tasks.startup
{
  public interface ICreateDependencyFactories
  {
    ICreateOneDependency create_factory<Contract, Implementation>() where Implementation : Contract;
    ICreateOneDependency create_factory<Implementation>(); 
    ICreateOneDependency create_factory<Contract>(Contract instance);
  }

  public class DependencyFactoryBuilder : ICreateDependencyFactories
  {
    IFetchDependencies container;

    public DependencyFactoryBuilder(IFetchDependencies container)
    {
      this.container = container;
    }

    public ICreateOneDependency create_factory<Contract, Implementation>() where Implementation : Contract
    {
      return new AutomaticDependencyFactory(container,
        StartupItems.Reflection.greediest_ctor,
        typeof(Implementation));
    }

    public ICreateOneDependency create_factory<Implementation>()
    {
      return create_factory<Implementation, Implementation>();
    }

    public ICreateOneDependency create_factory<Contract>(Contract instance)
    {
      return new SimpleDependencyFactory(() => instance);
    }
  }
}