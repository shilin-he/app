using System;
using System.Collections.Generic;
using app.utility.events;
using developwithpassion.specifications.extensions;
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

    public class when_a_handler_is_registered
    {
      
    }
    public class when_an_event_handler_is_registered : concern
    {
      public class and_it_is_not_already_in_the_list_of_handlers
      {
        Establish c = () =>
        {
          handlers = new Dictionary<string, IList<EventHandler>>();
          our_handler = delegate
          {
            raised = true;
          };
          depends.on(handlers);
        };

        Because b = () =>
          sut.register_listener(Events.ring, our_handler);

        It is_added_to_the_list_of_handlers_for_the_event = () =>
          handlers[Events.ring].ShouldContain(our_handler);

        static IDictionary<string, IList<EventHandler>> handlers;
        static bool raised;
        static EventHandler our_handler;
      }

      public class and_it_is_already_in_the_list_of_handlers
      {
        Establish c = () =>
        {
          handlers = new Dictionary<string, IList<EventHandler>>();
          our_handler = delegate
          {
            raised = true;
          };
          depends.on(handlers);
        };

        Because b = () =>
          sut.register_listener(Events.ring, our_handler);

        It is_added_to_the_list_of_handlers_for_the_event = () =>
        {
          handlers[Events.ring].ShouldContain(our_handler);
          handlers[Events.ring].Count.ShouldEqual(1);
        };

        static IDictionary<string, IList<EventHandler>> handlers;
        static bool raised;
        static EventHandler our_handler;
      }
    }

    public class when_an_listener_is_registered : concern
    {
      Establish c = () =>
      {
        target = new object();
        listener_scourer = depends.on<IScourForListenersOnAType>();
      };

      Because b = () =>
        sut.register_listener(target);

      It retrieves_all_of_the_applicable_listener_methods = () =>
        listener_scourer.received(x => x.get_event_handlers_on(target));

      static IScourForListenersOnAType listener_scourer;
      static object target;
    }
  }
}