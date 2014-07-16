using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingStartedClient.ServiceReference1;

namespace GettingStartedClient
{
  class Program
  {
    static void Main(string[] args)
    {
      var client = new CalculatorClient();
      Console.WriteLine("{0} + {1} = {2}", 2, 3, client.Add(2, 3));
      Console.WriteLine("{0} - {1} = {2}", 2, 3, client.Subtract(2, 3));
      Console.WriteLine("{0} * {1} = {2}", 2, 3, client.Multiply(2, 3));
      Console.WriteLine("{0} / {1} = {2}", 2, 3, client.Divide(2, 3));

      Console.ReadLine();

      client.Close();
    }
  }
}
