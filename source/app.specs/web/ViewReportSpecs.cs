using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.web
{
  [Subject(typeof(ViewReport<>))]
  public class ViewReportSpecs
  {
    public abstract class concern : Observes<IImplementAUserStory,
      ViewReport<TestReport>>
    {
    }

    public class TestReport
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutARequest>();
        display_engine = depends.on<IDisplayInformation>();
        the_report = new TestReport();

        depends.on<IGetAReportUsingARequest<TestReport>>(x =>
        {
          x.ShouldEqual(request);
          return the_report;
        });
      };

      Because b = () =>
        sut.process(request);

      It display_the_report = () =>
        display_engine.received(x => x.display(the_report));

      static IProvideDetailsAboutARequest request;
      static IDisplayInformation display_engine;
      static TestReport the_report;
    }
  }
}