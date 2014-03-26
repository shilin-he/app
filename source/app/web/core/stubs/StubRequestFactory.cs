using System.Web;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateARequest
  {
    public IProvideDetailsAboutARequest create_request_from(HttpContext context)
    {
      return new StubRequest();
    }

    class StubRequest : IProvideDetailsAboutARequest
    {
    }
  }
}