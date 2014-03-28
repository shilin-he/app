using System;

namespace app.tasks
{
  public interface IRunSteps
  {
    void run_step(Type step_type);
  }
}