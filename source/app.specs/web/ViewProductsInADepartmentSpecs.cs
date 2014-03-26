 using System.Collections.Generic;
 using app.web.application.catalogbrowsing;
 using app.web.core;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using Rhino.Mocks.Constraints;
namespace app.specs.web
{  
  [Subject(typeof(ViewProductsInADepartment))]  
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
        the_department = new DepartmentLineItem();
        the_products = new List<ProductLineItem>
        {
          new ProductLineItem()
        };

        request = fake.an<IProvideDetailsAboutARequest>();
        request.setup(x => x.map<DepartmentLineItem>()).Return(the_department);
        display_engine = depends.on<IDisplayInformation>();
        products = depends.on<IFindProducts>();
        products.setup(x => x.get_the_products_in_the_department(the_department)).Return(the_products);
      };

      Because b = () =>
        sut.process(request);

      It display_products_in_the_department = () =>
        display_engine.received(x => x.display(the_products));

      static IProvideDetailsAboutARequest request;
      static IDisplayInformation display_engine;
      static DepartmentLineItem the_department;
      static IEnumerable<ProductLineItem> the_products;
      static IFindProducts products;
    }
  }
}
