using System;
using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.catalogbrowsing
{
  public class ViewAgain<ReportModel> : IImplementAUserStory
  {
    IDisplayInformation display_engine;

    public ViewAgain(IDisplayInformation display_engine, IGetAReportUsingARequest<ReportModel> reports)
    {

    }


    public void process(IProvideDetailsAboutARequest request)
    {
      throw new NotImplementedException();
    }
  }
}