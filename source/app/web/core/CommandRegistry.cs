using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry : IFindCommandsToProcessRequests
  {
    private readonly IEnumerable<IProcessOneRequest> all_commands;
    ICreateASpecialCaseWhenACommandIsNotFound command_for_special_case;

    public CommandRegistry(IEnumerable<IProcessOneRequest> all_commands, ICreateASpecialCaseWhenACommandIsNotFound command_for_special_case)
    {
      this.all_commands = all_commands;
      this.command_for_special_case = command_for_special_case;
    }

    public IProcessOneRequest get_command_that_can_process(IProvideDetailsAboutARequest request)
    {
      return all_commands.FirstOrDefault(x => x.can_process(request)) ?? command_for_special_case(request);
    }
  }
}