using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry : IFindCommandsToProcessRequests
  {
    public CommandRegistry(IEnumerable<IProcessOneRequest> commands)
    {
      this.commands = commands;
    }

    IEnumerable<IProcessOneRequest> commands;
 
    public IProcessOneRequest get_command_that_can_process(IProvideDetailsAboutARequest request)
    {
      return commands.First(x => x.can_process(request));
    }
  }
}