﻿using System;

namespace app.utility.container.basic
{
  public delegate void IHandleDependencyCreationErrors(Type type_that_could_not_be_created,
  Exception inner_exception);
}