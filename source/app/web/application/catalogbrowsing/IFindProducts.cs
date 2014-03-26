using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
  public interface IFindProducts
  {
    IEnumerable<ProductLineItem> get_the_products_in_the_department(DepartmentLineItem department);
  }
}