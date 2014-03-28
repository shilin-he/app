using System;
using System.Collections;
using System.Collections.Generic;

namespace app.tasks
{
  public interface IBuildStartSteps
  {
    IBuildStartSteps followed_by<Step>() where Step : IRunAStartupStep;
    IEnumerable<Type> get_steps();
    void finish_with<Step>() where Step : IRunAStartupStep;
  }
}