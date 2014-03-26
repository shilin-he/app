namespace app.web.core.aspnet
{
  public interface IFindPathsToViews 
  {
    string get_path_to_view_for<ReportModel>();
  }
}