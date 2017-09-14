using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ProductInterfaces;


namespace ProductsClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IWCFProductService> channelFactory = new ChannelFactory<IWCFProductService>("ProductServiceEndpoint");
            IWCFProductService proxy = channelFactory.CreateChannel();
            
            //calls the server
            List<string> products = proxy.ListProducts().ToList();
            
            foreach (var p in products)
            {
                Console.WriteLine(p);
            }

            Console.ReadLine();
        }
    }
}
