using BlazorWasmSignalR.Client.Pages;
using BlazorWasmSignalR.Server.Models;
using BlazorWasmSignalR.Server.Models.Hub;
using BlazorWasmSignalR.Shared;
using BlazorWasmSignalR.Shared.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System.Net;

namespace BlazorWasmSignalR.Server.Workers;
public class SimpleWorker
{
    private HubConnection? hubConnection;
    string apiKey;


    public void SetHub(HubConnection hub, string apiKey)
    {
        this.hubConnection = hub;
        this.apiKey = apiKey;
    }

    //ApiKey = app?.ServiceProvider?.GetService<IOptions<OpenWeatherMapKey>>()?.Value?.ApiKey;

    public void ExecuteAsync(CancellationToken stoppingToken)
    {
        Task.Run(async() =>
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);

                hubConnection?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + " - " + DateTime.Now.Second.ToString("00"),
                    MessageType = "TIME"
                });
            }
        });

    }

    public async Task GetNews(CancellationToken stoppingToken)
    {
        await GetNewsCaller(stoppingToken);
    }


    private async Task GetNewsCaller(CancellationToken stoppingToken)
    {
        try
        {
            var url = "https://newsapi.org/v2/everything?" +
              "sources=ansa&" +
              "apiKey=" + apiKey;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# App");
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var news = JsonConvert.DeserializeObject<Root>(json);

            if (news is not null)
            {
                foreach (var item in news.articles)
                {
                    await Task.Delay(15000, stoppingToken);
                    var serializedArticle = JsonConvert.SerializeObject(item);
                    hubConnection?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                    {
                        Message = serializedArticle,
                        MessageType = nameof(Article)
                    });
                }
            }

            Console.WriteLine(json);
        }
        catch (Exception e)
        {
            var s = e.Message;
            Console.WriteLine(s);
        }
    }
}

