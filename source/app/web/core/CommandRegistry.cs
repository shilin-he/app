using System.Collections.Generic;
using System.Linq;
using app.web.core.stubs;

namespace app.web.core
{
  public class CommandRegistry : IFindCommandsToProcessRequests
  {
    IEnumerable<IProcessOneRequest> all_commands;
    ICreateASpecialCaseWhenACommandIsNotFound missing_command_factory;

    public CommandRegistry(IEnumerable<IProcessOneRequest> all_commands, ICreateASpecialCaseWhenACommandIsNotFound missing_command_factory)
    {
      this.all_commands = all_commands;
      this.missing_command_factory = missing_command_factory;
    }

    public CommandRegistry():this(new StubSetOfCommands(), StubSpecialCaseHandler.missing_handler)
    {
    }

    public IProcessOneRequest get_command_that_can_process(IProvideDetailsAboutARequest request)
    {
      var result = all_commands.FirstOrDefault(x => x.can_process(request));
      return result ?? missing_command_factory(request);
    }
  }
}