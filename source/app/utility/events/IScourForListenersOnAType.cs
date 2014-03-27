using System.Collections.Generic;

namespace app.utility.events
{
  public interface IScourForListenersOnAType
  {
    IEnumerable<IHandleAnEvent> get_event_handlers_on(object listener);
  }

  public interface IHandleAnEvent
  {
  }
}