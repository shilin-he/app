using System.Web;
using app.utility.container;

namespace app.web.core.aspnet
{
  public class RawHttpHandler : IHttpHandler
  {
    IProcessWebRequests front_controller;
    ICreateARequest request_factory;

    public RawHttpHandler(IProcessWebRequests front_controller, ICreateARequest request_factory)
    {
      this.front_controller = front_controller;
      this.request_factory = request_factory;
    }

    public RawHttpHandler():this(
      Fetch.me.an<IProcessWebRequests>(),
      Fetch.me.an<ICreateARequest>())
    {
    }

    public void ProcessRequest(HttpContext context)
    {
      var request = request_factory.create_request_from(context);
      front_controller.process(request);
    }

    public bool IsReusable
    {
      get { return false; }
    }
  }
}