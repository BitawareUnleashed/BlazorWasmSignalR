using BlazorWasmSignalR.Server.Models;
using BlazorWasmSignalR.Server.Models.Hub;
using BlazorWasmSignalR.Shared;
using BlazorWasmSignalR.Shared.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorWasmSignalR.Server.Workers;
public class SimpleWorker
{
    private HubConnection? hubConnection;

    public void SetHub(HubConnection hub)
    {
        this.hubConnection = hub;
    }

    public async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // eseguire la logica del servizio qui
            await Task.Delay(1000, stoppingToken);
            hubConnection?.SendAsync(nameof(IHub.Message), new NotificationTransport()
            {
                Message = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + " - " + DateTime.Now.Second.ToString("00"),
                MessageType = "TIME"
            });; ;
        }
    }
}
