namespace app.utility.events
{
  public delegate void CustomEvent<EventData>(object sender,
    PlainEventArgs<EventData> args);
}