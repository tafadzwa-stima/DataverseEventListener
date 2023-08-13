using Azure.Messaging.ServiceBus;

namespace DataverseEventListener
{
    public class Program
    {
        static void  Main(string[] args)
        {
            GetMessage();


            Console.ReadLine();
        }
        public static async Task GetMessage()
        {
            string connectionString = "Endpoint=sb://powerplatformnamespace.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=DrYVlJn7ZbS2rUTszn/R3y74dB04Q71rm+ASbEi2z3U=";
            string queueName = "powerplatformqueue";

           // RemoteExecutionContext context = null;

            //this is how you create a Queueclient with the new AzureService sdk
            var client = new ServiceBusClient(connectionString);

            var receiver = client.CreateReceiver(queueName);

            var receivedMessage = await receiver.ReceiveMessageAsync();

            if (receivedMessage.ContentType == "application/json")
            {
                Console.WriteLine("Message is JSON");
            }
            else { Console.WriteLine("message is not json"); }

            string body = receivedMessage.Body.ToString();

            Console.WriteLine(body);
            Console.ReadKey();


        }
    }
}