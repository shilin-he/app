using System;

namespace app.utility.container.basic
{
  public delegate ICreateOneDependency ICreateADependencyFactoryWhenItIsMissing(Type type_that_has_no_factory);
}