using app.web.core;

namespace app.web.application.catalogbrowsing
{
  public class ViewProductsInADepartment : IImplementAUserStory
  {
    IFindProducts products;
    IDisplayInformation display_engine;

    public ViewProductsInADepartment(IFindProducts products, IDisplayInformation display_engine)
    {
      this.products = products;
      this.display_engine = display_engine;
    }

    public void process(IProvideDetailsAboutARequest request)
    {
      var department = request.map<DepartmentLineItem>();
      display_engine.display(products.find_products_in(department));
    }
  }
}