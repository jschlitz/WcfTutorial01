using GettingStartedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorHost
{
  class Program
  {
    static void Main(string[] args)
    {
      //make uri
      var baseAddress = new Uri("http://localhost:8000/GettingStarted/");

      //step 2
      var selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

      try
      {
        //endpoint
        selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");

        //metadata
        var smb = new ServiceMetadataBehavior();
        smb.HttpGetEnabled = true;
        smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
        selfHost.Description.Behaviors.Add(smb);

        //Not clear if this is necessary, or if it just takes a long time for http://localhost:8000/GettingStarted to become ready
        var foo =selfHost.AddDefaultEndpoints();

        foreach (var item in foo)
        {
          Console.WriteLine("----------");
          Console.WriteLine(item.Address.ToString());
        }

        //begin
        selfHost.Open();
        Console.WriteLine("Calculator service started. Press enter to terminate.");
        Console.WriteLine();
        Console.ReadLine();

        selfHost.Close();
      }
      catch (CommunicationException ex)
      {
        Console.WriteLine("Exception! {0}", ex.Message);
        selfHost.Abort();
        Console.ReadLine();
      }
    }
  }
}
