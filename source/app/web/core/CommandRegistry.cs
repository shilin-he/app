namespace app.web.core
{
  public class CommandRegistry : IFindCommandsToProcessRequests
  {
    public IProcessOneRequest get_command_that_can_process(IProvideDetailsAboutARequest request)
    {
      throw new System.NotImplementedException();
    }
  }
}