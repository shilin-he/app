using app.utility;

namespace app.tasks.startup
{
  public delegate IRunATask ICombineStartupSteps (
  IRunATask first, IRunATask second);
}