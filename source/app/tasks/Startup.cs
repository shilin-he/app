using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using app.tasks.startup;
using app.utility.container;
using app.utility.container.basic;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.aspnet.stubs;
using app.web.core.stubs;

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

      factories.Add(typeof(IEnumerable<IProcessOneRequest>),
        new SimpleDependencyFactory(() => new StubSetOfCommands()));

      factories.Add(typeof(IFindPathsToViews),
        new SimpleDependencyFactory(() => new StubViewPathRegistry()));

      factories.Add(typeof(ICreateARequest),
        new SimpleDependencyFactory(() => new StubRequestFactory()));

      ICreateHandlers views = BuildManager.CreateInstanceFromVirtualPath;

      factories.Add(typeof(ICreateHandlers), new SimpleDependencyFactory(() => views));

      factories.Add(typeof(ICreateAView), 
        new SimpleDependencyFactory(() => new ReportViewFactory(
        container.an<IFindPathsToViews>(), container.an<ICreateHandlers>())));

      factories.Add(typeof(IDisplayInformation), new SimpleDependencyFactory(() => new WebFormDisplayEngine(
        container.an<ICreateAView>(),container.an<IGetTheCurrentlyRunningContext>())));

      IGetTheCurrentlyRunningContext current = () => HttpContext.Current;
      factories.Add(typeof(IGetTheCurrentlyRunningContext), new SimpleDependencyFactory(() => current));

      factories.Add(typeof(IProcessWebRequests),
        new SimpleDependencyFactory(() => 
          new FrontController(container.an<IFindCommandsToProcessRequests>())));

      factories.Add(typeof(IFindCommandsToProcessRequests), 
        new SimpleDependencyFactory(() => 
          new CommandRegistry(container.an<IEnumerable<IProcessOneRequest>>(), StartupItems.Errors.command_not_found_for_request)));
    } 

  }
}