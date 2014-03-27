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
    public static class FactoriesExtensions
    {
        public static void Add<T>(this IDictionary<Type, ICreateOneDependency> factories, Func<object> item_to_add)
        {
            factories.Add(typeof(T), new SimpleDependencyFactory(item_to_add));
        }
    }

  public class Startup
  {


    public static void the_application()
    {
      IDictionary<Type, ICreateOneDependency> factories = new Dictionary<Type, ICreateOneDependency>();
      var factory_registry = new DependencyFactories(factories, StartupItems.Errors.dependency_factory_missing);
      IFetchDependencies container = new Container(factory_registry, StartupItems.Errors.dependency_creation_error);
      Fetch.container_resolution = () => container;

      factories.Add<IProcessOneRequest>(() => new StubSetOfCommands());

      factories.Add<IFindPathsToViews>(() => new StubViewPathRegistry());

      factories.Add<ICreateARequest>(() => new StubRequestFactory());

      ICreateHandlers views = BuildManager.CreateInstanceFromVirtualPath;

      factories.Add<ICreateHandlers>(new SimpleDependencyFactory(() => views));

      factories.Add<ICreateAView>( 
        new SimpleDependencyFactory(() => new ReportViewFactory(
        container.an<IFindPathsToViews>(), container.an<ICreateHandlers>())));

      factories.Add<IDisplayInformation>(new SimpleDependencyFactory(() => new WebFormDisplayEngine(
        container.an<ICreateAView>(),container.an<IGetTheCurrentlyRunningContext>())));

      IGetTheCurrentlyRunningContext current = () => HttpContext.Current;
      factories.Add<IGetTheCurrentlyRunningContext>( new SimpleDependencyFactory(() => current));

      factories.Add<IProcessWebRequests>(
        new SimpleDependencyFactory(() => 
          new FrontController(container.an<IFindCommandsToProcessRequests>())));

      factories.Add<IFindCommandsToProcessRequests>(
        new SimpleDependencyFactory(() => 
          new CommandRegistry(container.an<IEnumerable<IProcessOneRequest>>(), StartupItems.Errors.command_not_found_for_request)));
    } 

  }
}