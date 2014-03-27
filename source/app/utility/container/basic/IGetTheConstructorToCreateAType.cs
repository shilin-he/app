using System;
using System.Reflection;

namespace app.utility.container.basic
{
  public delegate ConstructorInfo IGetTheConstructorToCreateAType(Type type);
}