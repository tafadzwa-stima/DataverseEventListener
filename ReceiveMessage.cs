using Azure.Messaging.ServiceBus;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataverseEventListener
{
    public class ReceiveMessage
    {
        public static async Task GetMessage()
        {
            string connectionString = "Endpoint=sb://powerplatformnamespace.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=DrYVlJn7ZbS2rUTszn/R3y74dB04Q71rm+ASbEi2z3U=";
            string queueName = "powerplatformqueue";

            RemoteExecutionContext context = null;


            var client = new ServiceBusClient(connectionString);

            ServiceBusReceiver receiver = client.CreateReceiver(queueName);

            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

            if (receivedMessage.ContentType =="application/json")
            {
                Console.WriteLine("Message is JSON");
            }
            else { Console.WriteLine("message is not json") ; }

            string body = receivedMessage.Body.ToString();

            Console.WriteLine(body);
           

        }
    }
}
