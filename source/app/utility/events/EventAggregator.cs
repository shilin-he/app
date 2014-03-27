using System;
using System.Collections.Generic;

namespace app.utility.events
{
  public class EventAggregator
  {
    IDictionary<string, IList<EventHandler>> handlers;

    public EventAggregator(IDictionary<string, IList<EventHandler>> handlers)
    {
      this.handlers = handlers;
    }

    public EventAggregator():this(new Dictionary<string, IList<EventHandler>>())
    {
    }

    public void register_listener(string event_name, EventHandler handler)
    {
      var event_handlers = handlers_for(event_name);
      if (event_handlers.Contains(handler)) return;
      event_handlers.Add(handler);
    }

    public void register_listener(object listener)
    {
      throw new NotImplementedException();
    }

    public void register_publisher(object publisher)
    {
      throw new NotImplementedException();
    }

    public IList<EventHandler> handlers_for(string event_name)
    {
      if (handlers.ContainsKey(event_name)) return handlers[event_name];

      var event_handlers = new List<EventHandler>();
      handlers[event_name] = event_handlers;
      return event_handlers;
    }
  }
}