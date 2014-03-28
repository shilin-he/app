using System.Web.UI.WebControls;

namespace app.utility
{
  public class ChainedTask : IRunATask
  {
    IRunATask first;
    IRunATask second;

    public ChainedTask(IRunATask first, IRunATask second)
    {
      this.first = first;
      this.second = second;
    }

    public void run()
    {
      first.run();
      second.run();
    }
  }
}