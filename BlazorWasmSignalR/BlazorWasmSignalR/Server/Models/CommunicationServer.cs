using BlazorWasmSignalR.Server.Workers;
using BlazorWasmSignalR.Shared;
using BlazorWasmSignalR.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BlazorWasmSignalR.Server.Models;

public class CommunicationServer : ICommunicationServer
{
    SimpleWorker worker;

    #region Constructor
    public CommunicationServer(SimpleWorker worker)
    {
        this.worker = worker;
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

    #region Methods and callbacks
    /// <summary>
    /// Initializes the SignalR connection with a configuration base address.
    /// </summary>
    /// <param name="baseAddress">The base address.</param>
    public async void Init(string baseAddress)
    {
        hubConnection = new HubConnectionBuilder()
                       .WithUrl(new Uri(baseAddress))
                       .WithAutomaticReconnect(reconnectionTimeouts)
                       .Build();
        await hubConnection.StartAsync();
        this.worker.SetHub(hubConnection);
        await worker.ExecuteAsync(new CancellationToken());
    }

    /// <inheritdoc cref="ICommunicationServer"/>>
    public void Send(object toSend) => hubConnection?.SendAsync(nameof(IHub.Message), toSend);

    /// <inheritdoc cref="ICommunicationServer"/>>
    public void SendChannelActivationMessage() => Send(new NotificationTransport { Message = "Initialization message", MessageType = "none" });

    #endregion
}
