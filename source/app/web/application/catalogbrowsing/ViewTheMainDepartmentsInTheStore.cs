using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheMainDepartmentsInTheStore: IImplementAUserStory
  {
    IFindDepartments departments;
    IDisplayInformation display_engine;

    public ViewTheMainDepartmentsInTheStore(IFindDepartments departments, IDisplayInformation display_engine)
    {
      this.departments = departments;
      this.display_engine = display_engine;
    }

    public ViewTheMainDepartmentsInTheStore():this(new StubDepartments(),
      new StubDisplayEngine())
    {
    }

    public void process(IProvideDetailsAboutARequest request)
    {
      var results = departments.get_the_main_departments();   
      display_engine.display(results);
    }
  }
}