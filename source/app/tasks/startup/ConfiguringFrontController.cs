using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using app.utility.container.basic;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.aspnet.stubs;
using app.web.core.stubs;

namespace app.tasks.startup
{
  public class ConfiguringFrontController : IRunAStartupStep
  {
    IProvideStartupServices services;

    public ConfiguringFrontController(IProvideStartupServices services)
    {
      this.services = services;
    }

    public void run()
    {
      services.register<IProcessWebRequests, FrontController>(LifeCycles.Singleton);
      services.register<IFindCommandsToProcessRequests, CommandRegistry>();
      services.register<IEnumerable<IProcessOneRequest>, StubSetOfCommands>();
      services.register<IDisplayInformation, WebFormDisplayEngine>();
      services.register<ICreateARequest, StubRequestFactory>();
      services.register<ICreateHandlers>(BuildManager.CreateInstanceFromVirtualPath);
      services.register<IGetTheCurrentlyRunningContext>(() => HttpContext.Current);
      services.register<ICreateAView, ReportViewFactory>();
      services.register(StartupItems.Errors.command_not_found_for_request);
      services.register(StartupItems.Errors.dependency_creation_error);
      services.register(StartupItems.Errors.dependency_factory_missing);
      services.register<IFindPathsToViews, StubViewPathRegistry>();
    }
  }
}