using System.Collections.Generic;

namespace app.utility.events
{
  public class EventAggregator
  {
    IDictionary<string, List<object>> handlers;

    public EventAggregator(IDictionary<string, List<object>> handlers)
    {
      this.handlers = handlers;
    }

    public EventAggregator() : this(new Dictionary<string, List<object>>())
    {
    }

    public void register_listener<Listener>(Listener listener)
    {
    }

    public void register_publisher<Publisher>(Publisher publisher)
    {
      throw new System.NotImplementedException();
    }
  }
}