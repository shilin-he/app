using System;

namespace app.utility.events
{
  [AttributeUsage(AttributeTargets.Method)]
  public class SubscriberAttribute : Attribute
  {
    public string event_name { get; private set; }

    public SubscriberAttribute(string event_name)
    {
      this.event_name = event_name;
    }
  }
  [AttributeUsage(AttributeTargets.Event)]
  public class PublisherAttribute : Attribute
  {
    public string event_name { get; private set; }

    public PublisherAttribute(string event_name)
    {
      this.event_name = event_name;
    }
  }
}