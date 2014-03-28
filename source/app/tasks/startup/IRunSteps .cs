using System;

namespace app.tasks.startup
{
  public interface IRunSteps
  {
    void run_step(Type step_type);
  }
}