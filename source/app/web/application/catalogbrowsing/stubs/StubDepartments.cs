using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowsing.stubs
{
  public class StubDepartments : IFindDepartments
  {
    public IEnumerable<DepartmentLineItem> get_the_main_departments()
    {
      return Enumerable.Range(1, 1000).Select(x => new DepartmentLineItem{name = x.ToString("Department 0")});
    }
  }
}