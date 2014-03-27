using app.tasks;
using app.utility.container;
using app.web.core;
using app.web.core.aspnet;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(Startup))]
  public class StartupSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_its_starts_up_the_app : concern
    {
      Because b = () =>
        Startup.the_application();

      It all_key_services_should_be_available = () =>
      {
        Fetch.me.an<IProcessWebRequests>().ShouldBeAn<FrontController>();
        Fetch.me.an<IFindCommandsToProcessRequests>().ShouldBeAn<CommandRegistry>();
        Fetch.me.an<IDisplayInformation>().ShouldBeAn<WebFormDisplayEngine>();
      };
        
    }
  }
}
