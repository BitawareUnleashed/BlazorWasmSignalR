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
    private HubConnection? hubConnection1;
    private HubConnection? hubConnection2;
    string apiKey;

    int time = 25;

    public async void SetHub(HubConnection hub, string apiKey)
    {
        this.apiKey = apiKey;
        hubConnection1 = new HubConnectionBuilder()
               .WithUrl(new Uri("https://localhost:7273/communicationhub"))
               .Build();
        await hubConnection1.StartAsync();

        hubConnection2 = new HubConnectionBuilder()
       .WithUrl(new Uri("https://localhost:7273/secondhub"))
       .Build();
        await hubConnection2.StartAsync();


        
    }

    //ApiKey = app?.ServiceProvider?.GetService<IOptions<OpenWeatherMapKey>>()?.Value?.ApiKey;

    public void ExecuteAsync(CancellationToken stoppingToken)
    {
        Task.Run(async () =>
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection1?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + " - " + DateTime.Now.Second.ToString("00"),
                    MessageType = "INTENSIVE1"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection1?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE2"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection1?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE3"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection1?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE4"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection1?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE5"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection1?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE6"
                });
            }
        });





        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection1?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE12"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection1?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE13"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection1?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE14"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection1?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE15"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection1?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE16"
                });
            }
        });




        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection2?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE22"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection2?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE23"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection2?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE24"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection2?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE25"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection2?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE26"
                });
            }
        });


        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection2?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE32"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection2?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE33"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection2?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE34"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection2?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE35"
                });
            }
        });

        Task.Run(async () =>
        {
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(time, stoppingToken);

                hubConnection2?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                {
                    Message = "DATA " + i++,
                    MessageType = "INTENSIVE36"
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
                    hubConnection1?.SendAsync(nameof(IHub.Message), new NotificationTransport()
                    {
                        Message = serializedArticle,
                        MessageType = nameof(Article)
                    });
                }
            }

            //Console.WriteLine(json);
        }
        catch (Exception e)
        {
            var s = e.Message;
            Console.WriteLine(s);
        }
    }
}

