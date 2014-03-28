 using app.specs.testutility;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs.tasks
{  
  public class MappingSpecs
  {
    public abstract class concern : Observes
    {
        
    }

    public class CustomerLineItem
    {
      public string customer_name { get; set; }
      public string customer_address { get; set; }
      public int customer_age { get; set; }
    }

    public class Customer
    {
      public string name { get; set; }
      public string address { get; set; }
      public int age { get; set; }
    }
   
    public class when_mapping_a_source_onto_a_target : concern
    {
      Establish c = () =>
      {
        source = new Customer
        {
          address = "blah",
          name = "John Doe",
          age = 42
        };
        target = new CustomerLineItem()
      };
        
      It first_observation = () =>

      static Customer source;
      static CustomerLineItem target;
    }
  }
}
