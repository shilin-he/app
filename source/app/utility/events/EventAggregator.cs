using System;
using System.Collections;
using System.Collections.Generic;

namespace app.utility.events
{
  public class EventAggregator
  {
    public EventAggregator(IDictionary<string, List<object>> handlers)
    {
      this.handlers = handlers;
    }

    IDictionary<string, List<object>> handlers;

    public void register_listener(string ring, Delegate our_handler)
    {
      if (!handlers.Keys.Contains(ring)) handlers[ring] = new List<object>();
      var ring_handlers = handlers[ring];
      if (!ring_handlers.Contains(our_handler)) ring_handlers.Add(our_handler);
    }
  }
}