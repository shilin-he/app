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
        {typeof(IEnumerable<DepartmentLineItem>), "~/views/DepartmentBrowser.aspx"},
        {typeof(IEnumerable<ProductLineItem>), "~/views/ProductBrowser.aspx"}
      };

      if  (! views.ContainsKey(typeof(ReportModel)))
        throw new Exception(string.Format("There is no view setup to display {0}", typeof(ReportModel).Name));

      return views[typeof(ReportModel)];
    }
  }
}