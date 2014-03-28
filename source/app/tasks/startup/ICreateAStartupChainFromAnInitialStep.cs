using System;

namespace app.tasks.startup
{
  public delegate IDefineStartupChains ICreateAStartupChainFromAnInitialStep(Type first_step);
}