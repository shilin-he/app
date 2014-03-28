using System;
using System.Collections.Generic;
using app.utility.container;
using app.utility.container.basic;

namespace app.tasks.startup
{
  public interface IProvideStartupServices
  {
    void register<Contract, Implementation>() where Implementation : Contract;
    void register<Contract>(Contract instance);
    void register<Implementation>();
    IFetchDependencies container { get; }
  }

  public class StartupServices : IProvideStartupServices
  {
    public ICreateDependencyFactories factories;
    public IDictionary<Type, ICreateOneDependency> services = new Dictionary<Type, ICreateOneDependency>();
    public IFetchDependencies container { get; private set; }

    public StartupServices(ICreateDependencyFactories factories, IFetchDependencies container)
    {
      this.factories = factories;
      this.container = container;
    }

    void register<Contract>(ICreateOneDependency factory)
    {
      services.Add(typeof(Contract), factory);
    }

    public void register<Contract, Implementation>() where Implementation: Contract
    {
      register<Contract>(factories.create_factory<Contract, Implementation>());
    }

    public void register<Implementation>()
    {
      register<Implementation>(factories.create_factory<Implementation>());
    }

    public void register<Contract>(Contract instance)
    {
      register<Contract>(factories.create_factory(instance));
    }
  }
}