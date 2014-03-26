using System.Web;
using System.Web.UI.WebControls;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.web
{
  [Subject(typeof(ReportViewFactory))]
  public class ReportViewFactorySpecs
  {
    public abstract class concern : Observes<ICreateAView,
      ReportViewFactory>
    {
    }

    public class when_creating_a_view_for_a_report : concern
    {
      Establish c = () =>
      {
        path = "blah.aspx";
        the_view = fake.an<IDisplayA<SomeReport>>();
        some_report = new SomeReport();
        view_path_registry = depends.on<IFindPathsToViews>();

        depends.on<ICreateHandlers>((the_path, the_type) =>
        {
          the_path.ShouldEqual(path);
          the_type.ShouldEqual(typeof(IDisplayA<SomeReport>));
          return the_view;
        });

        view_path_registry.setup(x => x.get_path_to_view_for<SomeReport>())
          .Return(path);
      };

      Because b = () =>
        result = sut.create_view_to_display(some_report);

      It creates_the_view_using_its_path_and_report_model_type = () =>
        result.ShouldEqual(the_view);

      It provides_the_view_its_report = () =>
        the_view.report.ShouldEqual(some_report);


      static SomeReport some_report;
      static IFindPathsToViews view_path_registry;
      static string path;
      static IHttpHandler result;
      static IDisplayA<SomeReport> the_view;
    }

    public class SomeReport
    {
      
    }
  }
}