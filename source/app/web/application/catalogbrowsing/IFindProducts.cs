using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
  public interface IFindProducts
  {
    IEnumerable<ProductLineItem> find_products_in(DepartmentLineItem the_department);
  }
}