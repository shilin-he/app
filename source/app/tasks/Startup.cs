using System;
using System.Collections.Generic;
using System.Web;
using app.tasks.startup;
using app.utility.container;
using app.utility.container.basic;
using app.web.core;
using app.web.core.aspnet;

namespace app.tasks
{
  public class Startup
  {
    public static void the_application()
    {
      IDictionary<Type, ICreateOneDependency> factories = new Dictionary<Type, ICreateOneDependency>();
      var factory_registry = new DependencyFactories(factories, StartupItems.Errors.dependency_factory_missing);
      IFetchDependencies container = new Container(factory_registry, StartupItems.Errors.dependency_creation_error);
      Fetch.container_resolution = () => container;

      factories.Add(typeof(IGetTheCurrentlyRunningContext), new SimpleDependencyFactory(() => HttpContext.Current));
      factories.Add(typeof(IProcessWebRequests), new SimpleDependencyFactory(() => 
        new FrontController(container.an<IFindCommandsToProcessRequests>())));
      factories.Add(typeof(IFindCommandsToProcessRequests), new SimpleDependencyFactory(() => 
        new CommandRegistry(container.an<IEnumerable<IProcessOneRequest>>(), StartupItems.Errors.command_not_found_for_request)));
    } 
  }
}