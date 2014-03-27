using System;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  public delegate void CustomEvent<EventData>(object sender,
    PlainEventArgs<EventData> args);

  public class PlainEventArgs<EventData> : EventArgs
  {
    public EventData details { get; private set; }

    public PlainEventArgs(EventData details)
    {
      this.details = details;
    }
  }

  public class AlarmDetails
  {
    public DateTime time_of_day { get; private set; }

    public AlarmDetails(DateTime time_of_day)
    {
      this.time_of_day = time_of_day;
    }
  }

  public class AlarmClock
  {
    public event CustomEvent<AlarmDetails> ring = delegate
    {
    };

    public void on_alarm_rang(AlarmDetails details)
    {
      ring(this, new PlainEventArgs<AlarmDetails>(details));
    }

    public void elapsed()
    {
      on_alarm_rang(new AlarmDetails(DateTime.Now));
    }
  }

  [Subject(typeof(AlarmClock))]
  public class AlarmClockSpecs
  {
    public abstract class concern : Observes<AlarmClock>
    {
    }

    public class when_the_time_elapses : concern
    {
      Establish c = () =>
      {
        event_raised = false;

        sut_setup.run(x =>
        {
          x.ring += (sender, args) =>
          {
            var time = args.details.time_of_day;
            event_raised = true;
          };   
        });
      };

      Because b = () =>
        sut.elapsed();

      It raises_the_ring_event = () =>
        event_raised.ShouldBeTrue();

      static bool event_raised;
    }
  }
}