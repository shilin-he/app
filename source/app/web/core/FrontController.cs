namespace app.web.core
{
  public class FrontController : IProcessWebRequests
  {
    IFindCommandsToProcessRequests command_registry;

    public FrontController(IFindCommandsToProcessRequests command_registry)
    {
      this.command_registry = command_registry;
    }

    public FrontController():this(new CommandRegistry())
    {
    }

    public void process(IProvideDetailsAboutARequest request)
    {
      var command = command_registry.get_command_that_can_process(request);
      command.process(request);
    }
  }
}