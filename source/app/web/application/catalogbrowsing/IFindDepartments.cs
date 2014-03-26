using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
  public interface IFindDepartments
  {
    IEnumerable<DepartmentLineItem> get_the_main_departments();
    IEnumerable<DepartmentLineItem> get_departments_in(DepartmentLineItem the_department);
  }
}