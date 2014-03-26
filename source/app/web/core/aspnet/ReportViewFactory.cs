using System.Web;
using System.Web.Compilation;
using app.web.core.aspnet.stubs;

namespace app.web.core.aspnet
{
  public class ReportViewFactory : ICreateAView
  {
    IFindPathsToViews view_path_registry;
    ICreateHandlers handler_factory;

    public ReportViewFactory(IFindPathsToViews view_path_registry, ICreateHandlers handler_factory)
    {
      this.view_path_registry = view_path_registry;
      this.handler_factory = handler_factory;
    }

    public ReportViewFactory():this(new StubViewPathRegistry(),
      BuildManager.CreateInstanceFromVirtualPath)
    {
    }

    public IHttpHandler create_view_to_display<ReportModel>(ReportModel model)
    {
      var path = view_path_registry.get_path_to_view_for<ReportModel>();
      var handler = (IDisplayA<ReportModel>) handler_factory(path, typeof(IDisplayA<ReportModel>));
      handler.report = model;
      return handler;
    }
  }
}