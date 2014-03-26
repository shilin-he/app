using System.Web;

namespace app.web.core.aspnet
{
  public interface ICreateAView
  {
    IHttpHandler create_view_to_display<ReportModel>(ReportModel model);
  }
}