using BlazorWasmSignalR.Shared.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace BlazorWasmSignalR.Server.Workers;
public class SimpleWorker
{
    private HubConnection? hubConnection1;
    string? apiKey;
    private string baseAddress;

    /// <summary>
    /// Sets the hub.
    /// </summary>
    /// <param name="hub">The hub.</param>
    /// <param name="apiKey">The API key.</param>
    public void SetHub(HubConnection hub, string apiKey, string baseAddress)
    {
        this.hubConnection1 = hub;
        this.apiKey = apiKey;
        this.baseAddress = baseAddress;
    }

    /// <summary>
    /// Executes the task.
    /// </summary>
    /// <param name="stoppingToken">The stopping token.</param>
    public void ExecuteAsync(CancellationToken stoppingToken)
    {
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            // Add to group
            await hubConnection.SendAsync("AddClientToGroup", "TIME20");

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME20", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });

        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME1", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME2", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME3", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME4", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME5", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME6", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME7", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME8", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME9", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME10", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME11", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME12", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME13", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME14", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME15", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME16", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME17", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME18", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        Task.Run(async () =>
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(baseAddress))
                .Build();
            await hubConnection.StartAsync();

            var i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(50, stoppingToken);

                _ = hubConnection?.SendAsync("SendToGroup", "TIME19", new NotificationTransport()
                {
                    Message = i++.ToString(),
                    MessageType = "TIME"
                }, stoppingToken);
                if (i > 010000) i = 0;
            }
        });
        //Task.Run(async () =>
        //{
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        await Task.Delay(50, stoppingToken);

        //        _ = hubConnection?.SendAsync("SendToGroup", "TIME", new NotificationTransport()
        //        {
        //            Message = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + " - " + DateTime.Now.Second.ToString("00"),
        //            MessageType = "TIME"
        //        }, stoppingToken);

        //        //hubConnection?.SendAsync(nameof(IHub.SendMessage), new NotificationTransport()
        //        //{
        //        //    SendMessage = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + " - " + DateTime.Now.Second.ToString("00"),
        //        //    MessageType = "TIME"
        //        //});
        //    }
        //});

    }

    /// <summary>
    /// Gets the news from website.
    /// </summary>
    /// <param name="stoppingToken">The stopping token.</param>
    public async Task GetNews(CancellationToken stoppingToken)=> await GetNewsCaller(stoppingToken);


    /// <summary>
    /// Gets the news caller.
    /// </summary>
    /// <param name="stoppingToken">The stopping token.</param>
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

            if (news is not null && news.articles is not null)
            {
                foreach (var item in news.articles)
                {
                    await Task.Delay(55000, stoppingToken);
                    var serializedArticle = JsonConvert.SerializeObject(item);

                    _ = hubConnection1?.SendAsync("SendToGroup", "NEWS", new NotificationTransport()
                    {
                        Message = serializedArticle,
                        MessageType = nameof(Article)
                    });



                    //hubConnection?.SendAsync(nameof(IHub.SendMessage), new NotificationTransport()
                    //{
                    //    SendMessage = serializedArticle,
                    //    MessageType = nameof(Article)
                    //});
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

