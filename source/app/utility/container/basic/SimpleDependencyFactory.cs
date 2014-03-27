using System;

namespace app.utility.container.basic
{
  public class SimpleDependencyFactory : ICreateOneDependency
  {
    Func<object> creator;

    public SimpleDependencyFactory(Func<object> creator)
    {
      this.creator = creator;
    }

    public object create()
    {
      return creator();
    }
  }
}