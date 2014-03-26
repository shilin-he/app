using System;
using System.Data;

namespace app
{
  public class Calculator
  {
    IDbConnection connection;

    public Calculator(IDbConnection connection)
    {
      this.connection = connection;
    }

    public int add(int first, int second)
    {
      if (first < 0 || second < 0)
        throw new ArgumentException("I can't add negative numbers :(");

      connection.Open();
      return first + second;
    }
  }
}