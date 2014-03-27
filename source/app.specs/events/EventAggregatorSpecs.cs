using System;
using System.Collections.Generic;
using app.utility.events;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.events
{
  [Subject(typeof(EventAggregator))]
  public class EventAggregatorSpecs
  {
    public abstract class concern : Observes<EventAggregator>
    {
    }

    public class Events
    {
      public const string ring = "Ring";
    }

    public class when_an_event_handler_is_registered : concern
    {
      public class and_it_is_not_already_in_the_list_of_handlers
      {
        Establish c = () =>
        {
          handlers = new Dictionary<string, List<object>>();
          our_handler = () =>
          {
            raised = true;
          };
          depends.on(handlers);
        };

        Because b = () =>
          sut.register_listener(Events.ring, our_handler);

        It is_added_to_the_list_of_handlers_for_the_event = () =>
          handlers[Events.ring].ShouldContain(our_handler);

        static IDictionary<string, List<object>> handlers;
        static bool raised;
        static Action our_handler;
      }
    }
  }
}