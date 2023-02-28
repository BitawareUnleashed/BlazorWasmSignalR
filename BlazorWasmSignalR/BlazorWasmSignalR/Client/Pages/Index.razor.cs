using BlazorWasmSignalR.Client.Services;
using BlazorWasmSignalR.Shared;
using BlazorWasmSignalR.Shared.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Numerics;
using System.Reflection.Metadata;

namespace BlazorWasmSignalR.Client.Pages;

public partial class Index
{
    //private HubConnection? hubConnection;
    private Article news;

    private string Watch1 = string.Empty;
    private string Watch2 = string.Empty;
    private string Watch3 = string.Empty;
    private string Watch4 = string.Empty;
    private string Watch5 = string.Empty;
    private string Watch6 = string.Empty;
    private string Watch7 = string.Empty;
    private string Watch8 = string.Empty;
    private string Watch9 = string.Empty;
    private string Watch10 = string.Empty;

    private string Watch11 = string.Empty;
    private string Watch12 = string.Empty;
    private string Watch13 = string.Empty;
    private string Watch14 = string.Empty;
    private string Watch15 = string.Empty;
    private string Watch16 = string.Empty;
    private string Watch17 = string.Empty;
    private string Watch18 = string.Empty;
    private string Watch19 = string.Empty;
    private string Watch20 = string.Empty;


    private string connectionId = string.Empty;

    private NotificationService? notificationService;
    protected override async Task OnInitializedAsync()
    {
        await Client1();
        await Client2();
        await Client3();
        await Client4();
        await Client5();
        await Client6();
        await Client7();
        await Client8();
        await Client9();
        await Client10();

        await Client11();
        await Client12();
        await Client13();
        await Client14();
        await Client15();
        await Client16();
        await Client17();
        await Client18();
        await Client19();
        await Client20();



        //hubConnection = new HubConnectionBuilder()
        //    .WithUrl(new Uri("https://localhost:7273/communicationhub"))
        //    .Build();

        //_ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        //hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        //    {
        //        Watch = message.Message ?? string.Empty;
        //        StateHasChanged();
        //    });
        //await hubConnection.StartAsync();

        //// Add to group
        //await hubConnection.SendAsync("AddClientToGroup", "TIME0");

        notificationService = new NotificationService(NavigationManager, Http);
        notificationService.MessageChanged += NotificationService_MessageChanged;
        _ = notificationService.InitializeNotifications();
    }


    private async Task Client1()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch1 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME1");
    }

    private async Task Client2()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch2 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME2");
    }

    private async Task Client3()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch3 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME3");
    }

    private async Task Client4()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch4 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME4");
    }

    private async Task Client5()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch5 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME5");
    }

    private async Task Client6()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch6 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME6");
    }

    private async Task Client7()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch7 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME7");
    }

    private async Task Client8()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch8 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME8");
    }

    private async Task Client9()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch9 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME9");
    }

    private async Task Client10()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch10 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME10");
    }





    private async Task Client11()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch11 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME11");
    }

    private async Task Client12()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch12 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME12");
    }

    private async Task Client13()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch13 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME13");
    }

    private async Task Client14()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch14 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME14");
    }

    private async Task Client15()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch15 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME15");
    }

    private async Task Client16()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch16 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME16");
    }

    private async Task Client17()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch17 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME17");
    }

    private async Task Client18()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch18 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME18");
    }

    private async Task Client19()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch19 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME19");
    }

    private async Task Client20()
    {
        var hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.SendMessage), message =>
        {
            Watch20 = message.Message ?? string.Empty;
            StateHasChanged();
        });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME20");
    }


    private void GetMyId(object context)
    {
        Console.WriteLine("Messaging hub connection. Arrived: " + context);
        connectionId = context.ToString();
        StateHasChanged();
    }

    private void NotificationService_MessageChanged(object? sender, Article? e)
    {
        if (e is not null)
        {
            news = e;
        }

        StateHasChanged();
    }

    public async ValueTask DisposeAsync()
    {
        //if (hubConnection is not null)
        //{
        //    await hubConnection.DisposeAsync();
        //}
    }

}

