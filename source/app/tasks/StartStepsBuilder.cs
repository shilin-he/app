using System;
using System.Collections;
using System.Collections.Generic;

namespace app.tasks
{
  public class StartStepsBuilder : IBuildStartSteps
  {
    IList<Type> steps = new List<Type>();

    IRunSteps step_runner;

    public StartStepsBuilder(IRunSteps step_runner)
    {
      this.step_runner = step_runner;
    }

    public IBuildStartSteps followed_by<Step>() where Step : IRunAStartupStep
    {
      steps.Add(typeof(Step));
      return this;
    }

    public void finish_with<Step>() where Step : IRunAStartupStep
    {
      steps.Add(typeof(Step));
      foreach (var step in steps)
      {
        step_runner.run_step(step);
      }
    }

    public IEnumerable<Type> get_steps()
    {
      foreach (var step in steps)
      {
        yield return step;
      }
    }
  }
}