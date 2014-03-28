using System;

namespace app.console
{
  //visibility - delegate - return type - Delegate Name - (parameters)
  public delegate void MessageGenerator();

  public class Delegates
  {
    static void say_hello()
    {
      Console.Out.WriteLine("Hello");
    }

    static void say_hello_again()
    {
      Console.Out.WriteLine("Hello again");
    }

    public static void run()
    {
      MessageGenerator generator = say_hello;
      generator += say_hello_again;
      generator += new MessageGenerator(say_hello);

      MessageGenerator other_dynamic = delegate
      {
        Console.Out.WriteLine("I am also dynamic");
      };

      other_dynamic += delegate
      {
        Console.Out.WriteLine("Now we are getting crazy");
      };

      generator += delegate
      {
        Console.Out.WriteLine("I am dynamic");
      };

      generator += other_dynamic;
      generator += generator;

      generator();
    }

  }
}