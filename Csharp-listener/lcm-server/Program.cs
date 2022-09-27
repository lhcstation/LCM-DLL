using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCM;
using LCM.LCM;


namespace LCM.Examples
{
    /// <summary>
    /// Demo listener, demonstrating interoperability with other implementations
    /// Just run this listener and use any of the example_t message senders
    /// </summary>
    class ExampleDisplay
    {
        public static void Main(string[] args)
        {
            LCM.LCM myLCM;
            try
            {
                myLCM = new LCM.LCM();
                myLCM.SubscribeAll(new SimpleSubscriber());
                while (true)
                    System.Threading.Thread.Sleep(1);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Ex: " + ex);
                Environment.Exit(1);
            }
        }
        internal class SimpleSubscriber : LCM.LCMSubscriber
        {
            public void MessageReceived(LCM.LCM lcm, string channel, LCM.LCMDataInputStream dins)
            {
                Console.WriteLine("RECV: " + channel);
                if (channel == "EXAMPLE")
                {
                    exlcm.example_t msg = new exlcm.example_t(dins);
                    //Console.WriteLine("Received message of the type example_t:");
                    //Console.WriteLine("  velFrontcoor         = '" + msg.velFrontcoorX + "'");
                    //Console.WriteLine("  velEndcoor      = '" + msg.velEndcoorX + "'");

                    Console.WriteLine("  current Time      = " + msg.time);

                    Console.WriteLine("  ======================================  ");


                }
            }
        }
    }
}