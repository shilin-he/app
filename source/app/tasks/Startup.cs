using System;
using app.tasks.startup;

namespace app.tasks
{
  public class Startup
  {
    public static void the_application()
    {
      Start.by<ConfiguringTheContainer>()
           .followed_by<ConfiguringRoutes>()
           .finish_with<ConfiguringFrontController>();
    }
  }

  public class Start
  {
    public static IBuildStartSteps by<Step>() where Step : IRunAStartupStep
    {
      var provide_startup_services = new ProvideStartupServices();
      IGetAStartupStep step_factory = type =>
      {
        return (IRunAStartupStep) Activator.CreateInstance(type, provide_startup_services);
      };

      return new StartStepsBuilder(new StepRunner(step_factory)).followed_by<Step>();
    }
  }
}