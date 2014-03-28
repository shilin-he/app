using System;
using app.utility;

namespace app.tasks.startup
{
  public delegate IRunATask ICreateSteps(Type type, params object[] parameters);
}