using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;

namespace app.web.core.stubs
{
  public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IProcessOneRequest> GetEnumerator()
    {
      yield return new WebCommand(x => true, new ViewProductsInADepartment());
      yield return new WebCommand(x => true, new ViewDepartmentsInADepartment());
      yield return new WebCommand(x => true, new ViewTheMainDepartmentsInTheStore());

    }
  }
}