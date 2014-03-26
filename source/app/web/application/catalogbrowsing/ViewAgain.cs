using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.catalogbrowsing
{
  public class ViewAgain : IImplementAUserStory
  {
    IDisplayInformation display_engine;
    IFindDepartments departments;

    public ViewAgain(IDisplayInformation display_engine, IFindDepartments departments)
    {
      this.display_engine = display_engine;
      this.departments = departments;
    }

    public ViewAgain() : this(new WebFormDisplayEngine(),
      new StubCatalog())
    {
    }

    public void process(IProvideDetailsAboutARequest request)
    {
      var results = departments.get_departments_in(request.map<DepartmentLineItem>());
      display_engine.display(results);
    }
  }
}