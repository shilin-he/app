using System;
using System.Diagnostics;

namespace app.utility.stubs
{
  public class StubTimer : ITimeThings
  {
    Stopwatch timer;

    public StubTimer()
    {
      timer = new Stopwatch();
    }

    public void start()
    {
      timer.Start();
    }

    public TimeSpan end()
    {
      timer.Stop();
      return timer.Elapsed;
    }
  }
}