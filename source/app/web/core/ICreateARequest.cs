using System.Web;

namespace app.web.core
{
  public interface ICreateARequest
  {
    IProvideDetailsAboutARequest create_request_from(HttpContext context);
  }
}