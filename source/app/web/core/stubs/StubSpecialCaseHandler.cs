using System;

namespace app.web.core.stubs
{
  public class StubSpecialCaseHandler
  {
    public static readonly ICreateASpecialCaseWhenACommandIsNotFound missing_handler =
      request =>
      {
        throw new NotImplementedException("There is no command that can handle this request");
      };
  }
}