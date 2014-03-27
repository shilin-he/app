using System;

namespace app.utility.container.basic
{
  public delegate Exception ICreateDependencyCreationErrors(Type type_that_could_not_be_created,
  Exception inner_exception);
}