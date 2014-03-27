using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.catalogbrowsing
{
  public class ViewReport<Report> : IImplementAUserStory
  {
    IDisplayInformation display_engine;
    IGetAReportUsingARequest<Report> query;

    public ViewReport(IDisplayInformation display_engine, IGetAReportUsingARequest<Report> query)
    {
      this.display_engine = display_engine;
      this.query = query;
    }

    public void process(IProvideDetailsAboutARequest request)
    {
      display_engine.display(query(request));
    }
  }
}