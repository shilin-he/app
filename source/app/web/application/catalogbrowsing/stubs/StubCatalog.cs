using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowsing.stubs
{
  public class StubCatalog : IFindProducts, IFindDepartments
  {
    public IEnumerable<DepartmentLineItem> get_the_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentLineItem {name = x.ToString("Department 0")});
    }

    public IEnumerable<DepartmentLineItem> get_departments_in(DepartmentLineItem the_department)
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentLineItem {name = x.ToString("Sub Department 0")});
    }

    public IEnumerable<ProductLineItem> get_the_products_in_the_department(DepartmentLineItem department)
    {
      return Enumerable.Range(1, 100).Select(x => new ProductLineItem {name = x.ToString("Product 0")});
    }
  }
}