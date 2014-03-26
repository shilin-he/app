using System;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;

namespace app.web.core.aspnet.stubs
{
  public class StubViewPathRegistry : IFindPathsToViews
  {
    public string get_path_to_view_for<ReportModel>()
    {
      var views = new Dictionary<Type, string>
      {
        {typeof(IEnumerable<DepartmentLineItem>), "~/views/DepartmentBrowser.aspx"}
      };

      return views[typeof(ReportModel)];
    }
  }
}