using System;
using System.Data;
using System.Security;
using System.Threading;

namespace app
{
  public class Calculator : ICalculate
  {
    IDbConnection connection;

    public Calculator(IDbConnection connection, int number, int number2)
    {
      this.connection = connection;
    }

    public int add(int first, int second)
    {
      if (first < 0 || second < 0)
        throw new ArgumentException("I can't add negative numbers :(");

      using (connection)
      using (var command = connection.CreateCommand())
      {
        connection.Open();
        command.ExecuteNonQuery();
      }
      return first + second;
    }

    public void shut_off()
    {
      if (Thread.CurrentPrincipal.IsInRole("blah")) return;

      throw new SecurityException();
    }
  }
}