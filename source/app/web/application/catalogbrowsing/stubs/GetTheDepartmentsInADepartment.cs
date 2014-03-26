using System.Collections.Generic;
using app.web.core;

namespace app.web.application.catalogbrowsing.stubs
{
  public class GetTheDepartmentsInADepartment: IRunAQuery<IEnumerable<DepartmentLineItem>>
  {
    public IEnumerable<DepartmentLineItem> query_using(IProvideDetailsAboutARequest request)
    {
      return new StubCatalog().get_departments_in(request.map<DepartmentLineItem>());
    }
  }
}