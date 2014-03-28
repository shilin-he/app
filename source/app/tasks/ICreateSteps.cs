using System;
using app.utility;

namespace app.tasks
{
  public delegate IRunATask ICreateSteps(Type type, params object[] parameters);
}