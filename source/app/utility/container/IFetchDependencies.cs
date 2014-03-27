using System;

namespace app.utility.container
{
  public interface IFetchDependencies
  {
    Dependency an<Dependency>();
    object an(Type dependency_type);
  }
}