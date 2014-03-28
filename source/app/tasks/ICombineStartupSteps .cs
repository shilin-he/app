using app.utility;

namespace app.tasks
{
  public delegate IRunATask ICombineStartupSteps (
  IRunATask first, IRunATask second);
}