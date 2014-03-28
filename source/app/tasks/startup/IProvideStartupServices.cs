using System;
using System.Collections.Generic;
using app.utility.container.basic;

namespace app.tasks.startup
{
  public interface IProvideStartupServices
  {
    void register<Contract, Implementation>() where Implementation : Contract;
    void register<Contract>(Contract instance);
    void register<Implementation>();
  }

  public class StartupServices : IProvideStartupServices
  {
    public ICreateDependencyFactories factories;
    public IDictionary<Type, ICreateOneDependency> services = new Dictionary<Type, ICreateOneDependency>();

    public StartupServices(ICreateDependencyFactories factories)
    {
      this.factories = factories;
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