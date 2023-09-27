// Install the C# / .NET helper library from twilio.com/docs/csharp/install

using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true);
        var config = builder.Build();

        // Find your Account SID and Auth Token at twilio.com/console
        // and set the environment variables. See http://twil.io/secure
        string accountSid = config["TWILIO_ACCOUNT_SID"];
        string authToken = config["TWILIO_AUTH_TOKEN"];

        TwilioClient.Init(accountSid, authToken);

        var message = MessageResource.Create(
            body: "Test",
            from: new Twilio.Types.PhoneNumber(config["FromPhoneNumber"]),
            to: new Twilio.Types.PhoneNumber(config["ToPhoneNumber"])
        );

        Console.WriteLine(message.Sid);
    }
}
