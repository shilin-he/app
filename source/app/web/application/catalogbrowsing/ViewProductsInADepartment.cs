using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.catalogbrowsing
{
  public class ViewProductsInADepartment : IImplementAUserStory
  {
    IDisplayInformation display_engine;
    IFindProducts products;

    public ViewProductsInADepartment(IDisplayInformation display_engine, IFindProducts products)
    {
      this.display_engine = display_engine;
      this.products = products;
    }

    public ViewProductsInADepartment() : this(new WebFormDisplayEngine(),
      new StubCatalog())
    {
    }

    public void process(IProvideDetailsAboutARequest request)
    {
      var results = products.get_the_products_in_the_department(request.map<DepartmentLineItem>());
      display_engine.display(results);
    }
  }
}
