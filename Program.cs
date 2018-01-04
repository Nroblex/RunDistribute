using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using DistributeLib;
using System.ServiceModel.Web;

namespace RunDistribute
{
    public class Program
    {
        static Uri myBaseAddress = new Uri("http://localhost:8081/Distribute/");
        static DistributeReference.DistributeServiceClient reference = new DistributeReference.DistributeServiceClient();
        static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof(Distribute), myBaseAddress);
            ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IDistributeService), new WebHttpBinding(), "");

            ServiceDebugBehavior dbg = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            dbg.HttpHelpPageEnabled = true;

            host.Open();

            Console.WriteLine("Service is up and running");
            Console.WriteLine("Press enter to quit ");
            Console.ReadLine();
            host.Close();
            /*
            using (ServiceHost host = new ServiceHost(typeof(DistributeLib.Distribute), myBaseAddress))
            {
                host.AddServiceEndpoint(typeof(IDistributeService), new WSHttpBinding(), "Distribute");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);
                

                host.Open();


                Console.WriteLine("DistributeService is running, listening at {0}", myBaseAddress);
                Console.WriteLine("To end this program press <ENTER>");

                

                Console.ReadLine();
                host.Close();
            }
            */



        }
    }
}
