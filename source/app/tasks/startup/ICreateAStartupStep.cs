using System;
using app.utility;

namespace app.tasks.startup
{
  public interface ICreateAStartupStep
  {
    IRunATask create_step(Type type);
  }

  public class StartupStepFactory : ICreateAStartupStep
  {
    IProvideStartupServices startup_services;

    public static ICreateSteps create_instance =
      StartupItems.Reflection.create<IRunATask>.create_instance;

    public StartupStepFactory(IProvideStartupServices startup_services)
    {
      this.startup_services = startup_services;
    }

    public IRunATask create_step(Type type)
    {
      return create_instance(type, startup_services);
    }
  }
}