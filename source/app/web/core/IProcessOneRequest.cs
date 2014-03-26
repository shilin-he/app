namespace app.web.core
{
  public interface IProcessOneRequest
  {
    void process(IProvideDetailsAboutARequest request);
    bool can_process(IProvideDetailsAboutARequest request);
  }
}