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


    public class Rang
    {
      public bool ran { get; private set; }

      public Rang(bool ran)
      {
        this.ran = ran;
      }
    }

    public class NewAlarmClock
    {
      [Publisher(Events.ring)]
      public event CustomEvent<Rang> ring = delegate
      {
      };

      public void trigger_ring()
      {
        ring(this, new PlainEventArgs<Rang>(new Rang(true)));
      }
    }

    public class ListenerOne
    {
      public bool responded { get; private set; }

      [Subscriber(Events.ring)]
      public void handle_ring(object sender, PlainEventArgs<Rang> details)
      {
        responded = true;
      }
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

      public class demo
      {
        public static void run()
        {
          var listener = new ListenerOne();
          var listener2 = new ListenerOne();
          var clock = new NewAlarmClock();
          var aggregator = new EventAggregator();

          aggregator.register_listener(listener);
          aggregator.register_listener(listener2);
          aggregator.register_publisher(clock);


          clock.trigger_ring();
          listener.responded == true;
          listener2.responded == true;
        }

      }
    }
  }
}