using System.Net.Http.Json;
using System.Text.Json;
using BlazorWasmSignalR.Shared;
using BlazorWasmSignalR.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorWasmSignalR.Client.Services;

public class NotificationService
{
    #region Fields
    private readonly string hubEndpoint = "https://localhost:7273/communicationhub";

    private const string TestEndpoint = "/api/v1/Test";


    /// <summary>
    /// Reconnection timings policy
    /// </summary>
    private readonly TimeSpan[] reconnectionTimeouts =
    {
        TimeSpan.FromSeconds(0),
        TimeSpan.FromSeconds(0),
        TimeSpan.FromSeconds(1),
        TimeSpan.FromSeconds(2),
        TimeSpan.FromSeconds(2),
        TimeSpan.FromSeconds(5),
        TimeSpan.FromSeconds(5),
        TimeSpan.FromSeconds(10),
        TimeSpan.FromSeconds(10),
        TimeSpan.FromSeconds(15),
        TimeSpan.FromSeconds(15),
    };
    #endregion

    #region Properties    
    /// <summary>
    /// Gets or sets the nav manager.
    /// </summary>
    /// <value>
    /// The nav manager.
    /// </value>
    public NavigationManager NavManager { get; set; }

    /// <summary>
    /// Gets or sets the HTTP.
    /// </summary>
    /// <value>
    /// The HTTP.
    /// </value>
    public HttpClient Http { get; set; }
    #endregion

    #region Events    

    public event EventHandler<Article>? MessageChanged;
    #endregion

    #region Constructors

    public NotificationService(NavigationManager navManager, HttpClient http)
    {
        NavManager = navManager;
        Http = http;
    }
    #endregion

    #region SignalR
    /// <summary>
    /// Gets or sets the hub connection.
    /// </summary>
    /// <value>
    /// The hub connection.
    /// </value>
    public HubConnection? HubConnection { get; set; }

    /// <summary>
    /// Initializes the notifications from machine.
    /// </summary>
    /// <exception cref="InvalidDataException"></exception>
    public async Task InitializeNotifications()
    {
        HubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .WithAutomaticReconnect(reconnectionTimeouts)
            .Build();
        _ = HubConnection.On<NotificationTransport>(nameof(IHub.Message), StringMessage);
        await HubConnection.StartAsync();
    }

    private void StringMessage(NotificationTransport context)
    {
        Console.WriteLine("Messaging hub connection. Arrived: " + context.MessageType);
        if (context.MessageType == nameof(Article))
        {
            var content = JsonSerializer.Deserialize<Article>(context.Message!);
            if (content is not null)
            {
                MessageChanged?.Invoke(this, content);
            }
        }
    }
    #endregion
}



