using System.Collections.Generic;
using app.web.core;

namespace app.web.application.catalogbrowsing.stubs
{
  public class GetTheProductsInADepartment :IRunAQuery<IEnumerable<ProductLineItem>>
  {
    public IEnumerable<ProductLineItem> query_using(IProvideDetailsAboutARequest request)
    {
      return new StubCatalog().get_the_products_in_the_department(
        request.map<DepartmentLineItem>());
    }
  }
}