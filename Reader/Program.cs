using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static HubConnection _connection;

    private static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        var servicesProvider = services.BuildServiceProvider();

        _connection = new HubConnectionBuilder()
                    .WithUrl("http://localhost:5045/notifications")
                    .Build();
        _connection.On<string>("SendMessageToAll", (message) => Console.WriteLine($"Received message: {message}"));
        _connection.Closed += async (error) =>
        {
            Console.WriteLine("Connection closed...");
            Console.ReadLine(); 
            Environment.Exit(0);
        };
        bool showMenu = true;
        do
        {
            try
            {
                showMenu = ShowMenu().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ooooops!!!");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Hit enter to continue");
                Console.ReadLine();
            }
        } while (showMenu);

    }

    static async Task<bool> ShowMenu()
    {
        Console.WriteLine("\nChoose an option:");
        Console.WriteLine("1. Connect");
        Console.WriteLine("2. Disconnect");
        Console.WriteLine("0. Exit");

        switch (Console.ReadLine())
        {
            case "1":
                return await Connect();
            case "2":
                return await Disconnect();
            case "0":
                return false;
            default:
                Console.WriteLine("\nChoose an option:");
                return true;
        }
    }

    private static async Task<bool> Disconnect()
    {
        if (_connection.State != HubConnectionState.Connected)
        {
            Console.WriteLine("Already disconnected");
        }
        else
        {
            await _connection.StopAsync();
            Console.WriteLine("Disconnected");
        }
        return true;
    }

    private static async Task<bool> Connect()
    {
        if (_connection.State != HubConnectionState.Connected)
        {
            await _connection.StartAsync();
            Console.WriteLine("Connected");
        }
        else
        {
            Console.WriteLine("Already connected");
        }
        return true;
    }
}