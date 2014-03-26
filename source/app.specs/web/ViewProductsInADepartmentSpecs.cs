 using System.Collections.Generic;
 using app.web.application.catalogbrowsing;
 using app.web.core;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs.web
{  
  [Subject(typeof(ViewProductsInADepartmentSpecs))]  
  public class ViewProductsInADepartmentSpecs
  {
    public abstract class concern : Observes<IImplementAUserStory,
      ViewProductsInADepartment>
    {
        
    }

   
    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutARequest>();
        selected_department = new DepartmentLineItem();
        departments = depends.on<IFindDepartments>();
        products = depends.on<IFindProducts>();
        display_engine = depends.on<IDisplayInformation>();
        departments_in_the_department = new List<DepartmentLineItem>
        {
          new DepartmentLineItem()
        };

        request.setup(x => x.map<DepartmentLineItem>()).Return(selected_department);
        departments.setup(x => x.get_departments_in(selected_department)).Return(departments_in_the_department);
      };

      Because b = () =>
        sut.process(request);

      It display_departments_in_the_department = () =>
        display_engine.received(x => x.display(departments_in_the_department));

      static IFindDepartments departments;
      static IFindProducts products;
      static IProvideDetailsAboutARequest request;
      static IDisplayInformation display_engine;
      static IEnumerable<DepartmentLineItem> departments_in_the_department;
      static DepartmentLineItem selected_department;
    }
  }
}
