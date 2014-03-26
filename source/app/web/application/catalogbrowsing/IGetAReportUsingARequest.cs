using app.web.core;

namespace app.web.application.catalogbrowsing
{
  public delegate ReportModel IGetAReportUsingARequest<out ReportModel>(IProvideDetailsAboutARequest request);

  public interface IRunAQuery<out ReportModel>
  {
    ReportModel query_using(IProvideDetailsAboutARequest request); 
  }
}