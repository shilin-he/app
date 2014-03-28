using System;
using app.tasks.startup;
using app.utility;

namespace app.tasks
{
  public class StepFactory : ICreateAStartupStep
  {
    IProvideStartupServices startup_services;

    public static ICreateSteps create_instance =
      StartupItems.Reflection.create<IRunATask>.create_instance;

    public StepFactory(IProvideStartupServices startup_services)
    {
      this.startup_services = startup_services;
    }

    public IRunATask create_step(Type type)
    {
      return create_instance(type, startup_services);
    }
  }
}