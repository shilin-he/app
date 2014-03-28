using System;

namespace app.tasks
{
  public delegate IRunAStartupStep IGetAStartupStep(Type type_of_startup_step);
}