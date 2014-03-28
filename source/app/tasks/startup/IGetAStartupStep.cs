using System;

namespace app.tasks.startup
{
  public delegate IRunAStartupStep IGetAStartupStep(Type type_of_startup_step);
}