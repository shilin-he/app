using System.Collections.Generic;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.web
{
  [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
  public class ViewTheMainDepartmentsInTheStoreSpecs
  {
    public abstract class concern : Observes<IImplementAUserStory,
      ViewTheMainDepartmentsInTheStore>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutARequest>();
        departments = depends.on<IFindDepartments>();
        display_engine = depends.on<IDisplayInformation>();
        the_main_departments = new List<DepartmentLineItem>
        {
          new DepartmentLineItem()
        };
        departments.setup(x => x.get_the_main_departments()).Return(the_main_departments);

      };

      Because b = () =>
        sut.process(request);

      It display_the_main_departments = () =>
        display_engine.received(x => x.display(the_main_departments));

      static IFindDepartments departments;
      static IProvideDetailsAboutARequest request;
      static IDisplayInformation display_engine;
      static IEnumerable<DepartmentLineItem> the_main_departments;
    }
  }
}