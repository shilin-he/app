using System;

namespace app.tasks
{
  public delegate IDefineStartupChains ICreateAStartupChainFromAnInitialStep(Type first_step);
}