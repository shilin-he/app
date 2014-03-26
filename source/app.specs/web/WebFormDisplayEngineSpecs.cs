using System.Web;
using app.specs.utility;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.web
{
  [Subject(typeof(WebFormDisplayEngine))]
  public class WebFormDisplayEngineSpecs
  {
    public abstract class concern : Observes<IDisplayInformation,
      WebFormDisplayEngine>
    {
    }

    public class when_displaying_information : concern
    {
      Establish c = () =>
      {
        a_context = ObjectFactory.web.create_http_context();
        view = fake.an<IHttpHandler>();
        depends.on<IGetTheCurrentlyRunningContext>(() => a_context);
        view_factory = depends.on<ICreateAView>();
        some_report = new SomeReport();

        view_factory.setup(x => x.create_view_to_display(some_report)).Return(view);
      };

      Because b = () =>
        sut.display(some_report);

      It tells_the_view_to_display_its_information_using_the_current_context = () =>
        view.received(x => x.ProcessRequest(a_context));
        
      static SomeReport some_report;
      static ICreateAView view_factory;
      static IHttpHandler view;
      static HttpContext a_context;
    }

    public class SomeReport
    {
    }
  }
}