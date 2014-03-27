using System;
using System.Collections.Generic;
using app.web.core;

namespace app.web.application.catalogbrowsing
{
  public class ControllerDispatchingCommand : IImplementAUserStory
  {
    IDisplayInformation display_engine;
    IGetAReportFromAControllerInvocation invocator;

    public ControllerDispatchingCommand(IDisplayInformation display_engine,
      IGetAReportFromAControllerInvocation invocator)
    {
      this.display_engine = display_engine;
      this.invocator = invocator;
    }

    public void process(IProvideDetailsAboutARequest request)
    {
      var result = invocator(request);
      display_engine.display(result);
    }
  }

  public class CatalogBrowsingController
  {
    public IEnumerable<DepartmentLineItem> get_the_main_departments()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<DepartmentLineItem> get_sub_departments(DepartmentLineItem department)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<ProductLineItem> get_products(DepartmentLineItem department)
    {
      throw new NotImplementedException();
    }
  }
}