using System;

namespace app.tasks
{
  public class StepRunner : IRunSteps
  {
    IGetAStartupStep get_a_startup_step;

    public StepRunner(IGetAStartupStep get_a_startup_step)
    {
      this.get_a_startup_step = get_a_startup_step;
    }

    public void run_step(Type step_type)
    {
      get_a_startup_step(step_type).run();
    }
  }
}