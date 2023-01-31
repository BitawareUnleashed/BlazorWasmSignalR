using BlazorWasmSignalR.Shared;
using BlazorWasmSignalR.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BlazorWasmSignalR.Server.Models;

public class CommunicationServer : ICommunicationServer
{
    
    #region Constructor

    public CommunicationServer(NavigationManager Navigator)
    {
        Init("https://localhost:7273/communicationhub");
    }

    #endregion

    #region Fields

    private HubConnection? hubConnection;

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

    #endregion

    #region Methods and callbacks

    /// <summary>
    /// Callback of client OnEventReceived.
    /// </summary>
    /// <param name="obj">The object.</param>
    private void ClientOnEventReceived(object obj)
    {
        var objectTypeName = string.Empty;
        var jsonSerializedObject = JsonSerializer.Serialize(obj);
        if (obj.GetType().ToString().LastIndexOf('.') > 0)
        {
            objectTypeName = obj.GetType().ToString()[(obj.GetType().ToString().LastIndexOf('.') + 1)..];
        }

        var toSend = new NotificationTransport
        {
            Message = jsonSerializedObject,
            MessageType = objectTypeName,
        };
        Send(toSend);
    }

    /// <summary>
    /// Initializes the SignalR connection with a configuration base address.
    /// </summary>
    /// <param name="baseAddress">The base address.</param>
    private async void Init(string baseAddress)
    {
        hubConnection = new HubConnectionBuilder()
                       .WithUrl(new Uri(baseAddress))
                       .WithAutomaticReconnect(reconnectionTimeouts)
                       .Build();
        await hubConnection.StartAsync();
    }

    /// <inheritdoc cref="ICommunicationServer"/>>
    public void Send(object toSend) => hubConnection?.SendAsync(nameof(IHubClient.Message), toSend);

    /// <inheritdoc cref="ICommunicationServer"/>>
    public void SendChannelActivationMessage() => Send(new NotificationTransport { Message = "Initialization message", MessageType = "none" });

    #endregion
}
