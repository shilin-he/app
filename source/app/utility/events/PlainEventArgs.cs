using System;

namespace app.utility.events
{
  public class PlainEventArgs<EventData> : EventArgs
  {
    public EventData details { get; private set; }

    public PlainEventArgs(EventData details)
    {
      this.details = details;
    }
  }
}