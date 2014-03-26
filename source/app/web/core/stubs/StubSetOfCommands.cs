using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;
using app.web.application.catalogbrowsing.stubs;

namespace app.web.core.stubs
{
  public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IProcessOneRequest> GetEnumerator()
    {
      yield return create_view_command(new GetTheProductsInADepartment());
      yield return create_view_command(new GetTheMainDepartments());
      yield return create_view_command(new GetTheDepartmentsInADepartment());
    }

    IProcessOneRequest create_view_command<Report>(IGetAReportUsingARequest<Report> query)
    {
      return new WebCommand(x => true, new ViewReport<Report>(query));
    }

    IProcessOneRequest create_view_command<Report>(IRunAQuery<Report> query)
    {
      return create_view_command(query.query_using);
    }
  }
}