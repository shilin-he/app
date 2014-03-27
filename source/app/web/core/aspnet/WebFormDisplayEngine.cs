namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayInformation
  {
    ICreateAView view_factory;
    IGetTheCurrentlyRunningContext current_context_resolution;

    public WebFormDisplayEngine(ICreateAView view_factory, IGetTheCurrentlyRunningContext current_context_resolution)
    {
      this.view_factory = view_factory;
      this.current_context_resolution = current_context_resolution;
    }

    public void display<DisplayModel>(DisplayModel model)
    {
      var view = view_factory.create_view_to_display(model);
      view.ProcessRequest(current_context_resolution());
    }
  }
}