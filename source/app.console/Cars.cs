using System;

namespace app.console
{
  class Cars
  {
    public class Garage
    {
      public string name { get; set; }

      public void book_car_for_service()
      {
        Console.Out.WriteLine(string.Format("Booking the car in for service at", this.name));
      }
    }

    public delegate void BreakDown();

    public class Car
    {
      int number_of_kilometers_to_breakdown;
      int kilometers_driven;

      public event BreakDown garages = delegate
      {
      };

      public Car(int number_of_kilometers_to_breakdown)
      {
        this.number_of_kilometers_to_breakdown = number_of_kilometers_to_breakdown;
      }

      public void drive(int kilometers)
      {
        kilometers_driven += kilometers;
        Console.Out.WriteLine(string.Format("I drove another {0} kilometers", kilometers));

        if (kilometers_driven >= number_of_kilometers_to_breakdown)
        {
          Console.Out.WriteLine("I brokedown");
          garages();
        }
      }
    }

    public static void run()
    {
      var broke_down = false;
      var garage1 = new Garage {name = "First Garage"};
      var garage2 = new Garage {name = "Second Garage"};
      var car = new Car(40);

      car.garages += delegate
      {
        broke_down = true;
      };
      car.garages += garage1.book_car_for_service;
      car.garages += garage2.book_car_for_service;

      while (! broke_down)
      {
        car.drive(10); 
      }
    }
  }
}