using System;

namespace app.web.core.aspnet
{
  public delegate object ICreateHandlers(string path, Type handler_type);
}