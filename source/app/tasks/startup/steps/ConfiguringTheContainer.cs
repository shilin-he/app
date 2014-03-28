using System;
using System.Collections.Generic;
using app.utility.container;
using app.utility.container.basic;

namespace app.tasks.startup.steps
{
  public class ConfiguringTheContainer : IRunAStartupStep
  {
    public ConfiguringTheContainer(IProvideStartupServices services)
    {
    }

    public void run()
    {
      var factories = new Dictionary<Type, ICreateOneDependency>();
      var dependency_factories = new DependencyFactories(factories, StartupItems.Errors.dependency_factory_missing);
      var container = new Container(dependency_factories, StartupItems.Errors.dependency_creation_error);
      var builder = new DependencyFactoryBuilder(container);
      var services = new StartupServices(builder, container)
      {
        services = factories
      };

      services.register<IFetchDependencies>(container);
      services.register<ICreateDependencyFactories>(builder);
      services.register<IProvideStartupServices>(services);

      Fetch.container_resolution = () => container;
    }
  }
}