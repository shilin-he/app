namespace app.web.core
{
  public interface IProcessOneRequest : IImplementAUserStory
  {
    bool can_process(IProvideDetailsAboutARequest request);
  }
}