 using System.Collections.Generic;
 using app.web.application.catalogbrowsing;
 using app.web.core;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using Rhino.Mocks.Constraints;

namespace app.specs.web
{  
  [Subject(typeof(ViewAgain))]  
  public class ViewAgainSpecs
  {
    public abstract class concern : Observes<IImplementAUserStory,
      ViewAgain>
    {
        
    }

   
    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutARequest>();
        display_engine = depends.on<IDisplayInformation>();
        the_report = new List<ProductLineItem>
        {
          new ProductLineItem()
        }; 
        reports = depends.on<IFindReports>();

        reports.find_report<DepartmentLineItem, IEnumerable<ProductLineItem>>(input);
        reports.setup(x => x.find_report<DepartmentLineItem, IEnumerable<ProductLineItem>>(input)).Return(the_report);

        request.setup(x => x.map<DepartmentLineItem>()).Return(input);
      };

      Because b = () =>
        sut.process(request);

      It display_report = () =>
        display_engine.received(x => x.display(the_report));

      static IProvideDetailsAboutARequest request;
      static IDisplayInformation display_engine;
      static IFindReports reports;
      static DepartmentLineItem input;
      static IEnumerable<ProductLineItem> the_report;
    }
  }
}
