namespace app.web.application.catalogbrowsing
{
  public interface IFindReports
  {
    ReportModel find_report<InputModel, ReportModel>(InputModel input);
  }
}