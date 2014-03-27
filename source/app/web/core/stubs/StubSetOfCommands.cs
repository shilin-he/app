using System;
using System.Collections;
using System.Collections.Generic;
using app.utility.stubs;
using app.web.application.catalogbrowsing;
using app.web.application.catalogbrowsing.stubs;

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
      throw new NotImplementedException();
    }

    IProcessOneRequest create_view_command<Report>(IGetAReportUsingARequest<Report> query)
    {
      return new WebCommand(x => true, create_feature(query));
    }

    static IImplementAUserStory create_feature<Report>(IGetAReportUsingARequest<Report> query)
    {
      throw new NotImplementedException();
    }

    static IImplementAUserStory decorate(IImplementAUserStory feature)
    {
      feature = new TimedFeature(new StubTimer(), feature, Console.WriteLine);
      return feature;
    }

    IProcessOneRequest create_view_command<Report>(IRunAQuery<Report> query)
    {
      return create_view_command(query.query_using);
    }
  }
}