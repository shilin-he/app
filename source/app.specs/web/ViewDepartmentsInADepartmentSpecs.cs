 using System.Collections.Generic;
 using app.web.application.catalogbrowsing;
 using app.web.core;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs.web
{  
  [Subject(typeof(ViewDepartmentsInADepartment))]  
  public class ViewDepartmentsInADepartmentSpecs
  {
    public abstract class concern : Observes<IImplementAUserStory,
      ViewDepartmentsInADepartment>
    {
        
    }

   
    public class when_process : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutARequest>();
        the_department = new DepartmentLineItem();
        departments = depends.on<IFindDepartments>();
        display_engine = depends.on<IDisplayInformation>();
        departments_in_the_department = new List<DepartmentLineItem>
        {
          new DepartmentLineItem()
        };
        departments.setup(x => x.get_departments_in(the_department)).Return(departments_in_the_department);
      };

      Because b = () =>
        sut.process(request);

      It display_departments_in_the_department = () =>
        display_engine.received(x => x.display(departments_in_the_department));

      static IFindDepartments departments;
      static IProvideDetailsAboutARequest request;
      static IDisplayInformation display_engine;
      static IEnumerable<DepartmentLineItem> departments_in_the_department;
      static DepartmentLineItem the_department;
    }
  }
}
