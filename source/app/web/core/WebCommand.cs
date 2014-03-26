namespace app.web.core
{
  public class WebCommand: IProcessOneRequest
  {
    IMatchARequest request_specification;
    IImplementAUserStory feature;

    public WebCommand(IMatchARequest request_specification, IImplementAUserStory feature)
    {
      this.request_specification = request_specification;
      this.feature = feature;
    }

    public void process(IProvideDetailsAboutARequest request)
    {
      feature.process(request);
    }

    public bool can_process(IProvideDetailsAboutARequest request)
    {
      return request_specification(request);
    }
  }
}