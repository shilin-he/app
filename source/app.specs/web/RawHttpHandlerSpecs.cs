 using System.Web;
 using app.specs.utility;
 using app.web.core;
 using app.web.core.aspnet;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs.web
{  
  [Subject(typeof(RawHttpHandler))]  
  public class RawHttpHandlerSpecs
  {
    public abstract class concern : Observes<IHttpHandler,
      RawHttpHandler>
    {
        
    }

    public class when_processing_an_http_context   : concern
    {
      Establish c = () =>
      {
        front_controller = depends.on<IProcessWebRequests>();
        request_factory = depends.on<ICreateARequest>();

        an_http_context_based_request = ObjectFactory.web.create_http_context();
        a_new_request = fake.an<IProvideDetailsAboutARequest>();

        request_factory.setup(x => x.create_request_from(an_http_context_based_request))
          .Return(a_new_request);
      };

      Because b = () =>
        sut.ProcessRequest(an_http_context_based_request);

      It delegates_the_processing_of_a_request_created_from_the_context_to_the_front_controller = () =>
        front_controller.received(x => x.process(a_new_request));

      static IProcessWebRequests front_controller;
      static IProvideDetailsAboutARequest a_new_request;
      static HttpContext an_http_context_based_request;
      static ICreateARequest request_factory;
    }
  }
}
