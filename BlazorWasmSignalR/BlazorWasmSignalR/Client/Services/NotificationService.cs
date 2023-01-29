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
    private readonly string hubEndpoint = "https://localhost:5001/communicationhub";

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

    public event EventHandler<int?>? AxesOverrideSafetyLimitRatioChanged;
    #endregion

    #region Constructors

    public NotificationService(NavigationManager navManager, HttpClient http)
    {
        NavManager = navManager;
        Http = http;
        _ = InitializeNotifications();
        Task.Run(async() =>
        {
            await TestHttpGet();
        });
    }
    #endregion

    #region Methods

    public async Task TestHttpGet()
    {
        try
        {
            var ret = await Http.GetFromJsonAsync<string>(@$"{TestEndpoint}");
            if (ret is not null)
            {

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
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
    private async Task InitializeNotifications()
    {
        IHubClient hubClientMethodsNames;
        HubConnection = new HubConnectionBuilder()
            .WithUrl(NavManager.ToAbsoluteUri(hubEndpoint))
            .WithAutomaticReconnect(reconnectionTimeouts)
            .Build();
        _ = HubConnection.On<NotificationTransport>(nameof(hubClientMethodsNames.ReceiveMessage), context =>
        {
            Console.WriteLine("Messaging hub connection. Arrived: " + context.MessageType);
            //if (context.MessageType != nameof(AxesFeedOverrideChanged))
            //{
            //    return;
            //}

            //var content = JsonSerializer.Deserialize<AxesFeedOverrideChanged>(context.Message!);
            //if (content is not null)
            //{
            //    if (SafetyLimitRatio != content.SafetyLimitRatio)
            //    {
            //        SafetyLimitRatio = content.SafetyLimitRatio;
            //        AxesOverrideSafetyLimitRatioChanged?.Invoke(this, SafetyLimitRatio);
            //    }
            //}
        });
        await HubConnection.StartAsync();
    }

    #endregion
}

