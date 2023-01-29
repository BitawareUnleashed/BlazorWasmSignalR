using BlazorWasmSignalR.Server.Models.Hub;
using BlazorWasmSignalR.Shared.Models;

namespace BlazorWasmSignalR.Server.Workers;
public class SimpleWorker
{
    private CommunicationHub hub;

    public SimpleWorker(CommunicationHub hub)
    {
        this.hub = hub;
    }
    public async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // eseguire la logica del servizio qui
            await Task.Delay(1000, stoppingToken);
            hub?.SendMessage(new NotificationTransport()
            {
                Message = "My message",
                MessageType = "MESSAGE"
            });
        }
    }
}
