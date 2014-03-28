namespace app.utility
{
  public static class TaskExtensions
  {
    public static IRunATask combine_with(this IRunATask first, IRunATask second)
    {
      return new ChainedTask(first, second); 
    }
  }
}