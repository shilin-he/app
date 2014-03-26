 using System.Collections.Generic;
 using app.web.application.catalogbrowsing;
 using app.web.core;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs.web
{
    [Subject(typeof (ViewAgain<>))]
    public class ViewAgainSpecs
    {
        public abstract class concern : Observes<IImplementAUserStory,
            ViewAgain<TestReport>>
        {

        }

        public class TestReport
        {
        }

        public class when_run : concern
        {
            private Establish c = () =>
            {
                request = fake.an<IProvideDetailsAboutARequest>();
                reports = depends.on<IGetAReportUsingARequest<TestReport>>();
                display_engine = depends.on<IDisplayInformation>();

                reports.setup(x => x.get_report(request)).Return(the_report);
            };

            private Because b = () =>
                sut.process(request);

            private It display_the_report = () =>
                display_engine.received(x => x.display(the_report));

            private static IGetAReportUsingARequest<TestReport> reports;
            private static IProvideDetailsAboutARequest request;
            private static IDisplayInformation display_engine;
            private static TestReport the_report;
        }
    }
}
