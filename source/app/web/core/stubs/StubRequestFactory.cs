using System;
using System.Web;
using app.web.application.catalogbrowsing;

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
      public InputModel map<InputModel>()
      {
        return Activator.CreateInstance<InputModel>();
      }
    }
  }
}