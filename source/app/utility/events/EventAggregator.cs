using System;
using System.Collections.Generic;
using System.Reflection;

namespace app.utility.events
{
  public class EventAggregator
  {
    IDictionary<string, IList<EventHandler>> handlers;
    IScourForListenersOnAType handler_resolution;

    public EventAggregator(IDictionary<string, IList<EventHandler>> handlers, IScourForListenersOnAType handler_resolution)
    {
      this.handlers = handlers;
      this.handler_resolution = handler_resolution;
    }

    public void register_listener(string event_name, EventHandler handler)
    {
      var event_handlers = handlers_for(event_name);
      if (event_handlers.Contains(handler)) return;
      event_handlers.Add(handler);
    }

    public void register_listener(object listener)
    {
      var handlers = handler_resolution.get_event_handlers_on(listener);

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