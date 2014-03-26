using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
  public class ViewDepartmentsInADepartment: IImplementAUserStory
  {
    IDisplayInformation display_engine;
    IFindDepartments departments;

    public ViewDepartmentsInADepartment(IDisplayInformation display_engine, IFindDepartments departments)
    {
      this.display_engine = display_engine;
      this.departments = departments;
    }

    public ViewDepartmentsInADepartment():this(new WebFormDisplayEngine(),
      new StubDepartments() )
    {
    }

    public void process(IProvideDetailsAboutARequest request)
    {
      var results = departments.get_departments_in(request.map<DepartmentLineItem>());
      display_engine.display(results);
    }
  }
}