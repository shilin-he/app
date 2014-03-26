namespace app.web.core
{
  public interface IFindCommandsToProcessRequests
  {
    IProcessOneRequest get_command_that_can_process(IProvideDetailsAboutARequest request);
  }
}