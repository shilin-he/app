using System;
using app.utility;

namespace app.tasks
{
  public interface ICreateAStartupStep
  {
    IRunATask create_step(Type type);
  }
}