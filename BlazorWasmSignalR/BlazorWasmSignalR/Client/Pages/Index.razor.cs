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
    private HubConnection? hubConnection1;
    private HubConnection? hubConnection2;
    private Article news;

    private string Watch = string.Empty;
    private string data2 = string.Empty;
    private string data3 = string.Empty;
    private string data4 = string.Empty;
    private string data5 = string.Empty;
    private string data6 = string.Empty;

    private string data12 = string.Empty;
    private string data13 = string.Empty;
    private string data14 = string.Empty;
    private string data15 = string.Empty;
    private string data16 = string.Empty;

    private string data22 = string.Empty;
    private string data23 = string.Empty;
    private string data24 = string.Empty;
    private string data25 = string.Empty;
    private string data26 = string.Empty;

    private string data32 = string.Empty;
    private string data33 = string.Empty;
    private string data34 = string.Empty;
    private string data35 = string.Empty;
    private string data36 = string.Empty;


    //private NotificationService? notificationService;
    protected override async Task OnInitializedAsync()
    {
        hubConnection1 = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        hubConnection1.On<NotificationTransport>(nameof(IHub.Message), message =>
            {
                if (message.MessageType == "INTENSIVE1")
                {
                    Watch = message.Message ?? string.Empty;
                    StateHasChanged();
                }

                if (message.MessageType == "INTENSIVE2")
                {
                    data2 = message.Message ?? string.Empty;
                }
                if (message.MessageType == "INTENSIVE3")
                {
                    data3 = message.Message ?? string.Empty;
                }
                if (message.MessageType == "INTENSIVE4")
                {
                    data4 = message.Message ?? string.Empty;
                }
                if (message.MessageType == "INTENSIVE5")
                {
                    data5 = message.Message ?? string.Empty;
                }
                if (message.MessageType == "INTENSIVE6")
                {
                    data6 = message.Message ?? string.Empty;
                }


                if (message.MessageType == "INTENSIVE12")
                {
                    data12 = message.Message ?? string.Empty;
                    StateHasChanged();
                }
                if (message.MessageType == "INTENSIVE13")
                {
                    data13 = message.Message ?? string.Empty;
                    StateHasChanged();
                }
                if (message.MessageType == "INTENSIVE14")
                {
                    data14 = message.Message ?? string.Empty;
                    StateHasChanged();
                }
                if (message.MessageType == "INTENSIVE15")
                {
                    data15 = message.Message ?? string.Empty;
                    StateHasChanged();
                }
                if (message.MessageType == "INTENSIVE16")
                {
                    data16 = message.Message ?? string.Empty;
                    StateHasChanged();
                }
            });
        await hubConnection1.StartAsync();

        hubConnection2 = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/secondhub"))
            .Build();

        hubConnection2.On<NotificationTransport>(nameof(IHub.Message), message =>
        {
            if (message.MessageType == "INTENSIVE22")
            {
                data22 = message.Message ?? string.Empty;
            }
            if (message.MessageType == "INTENSIVE23")
            {
                data23 = message.Message ?? string.Empty;
            }
            if (message.MessageType == "INTENSIVE24")
            {
                data24 = message.Message ?? string.Empty;
            }
            if (message.MessageType == "INTENSIVE25")
            {
                data25 = message.Message ?? string.Empty;
            }
            if (message.MessageType == "INTENSIVE26")
            {
                data26 = message.Message ?? string.Empty;
            }

            if (message.MessageType == "INTENSIVE32")
            {
                data32 = message.Message ?? string.Empty;
            }
            if (message.MessageType == "INTENSIVE33")
            {
                data33 = message.Message ?? string.Empty;
            }
            if (message.MessageType == "INTENSIVE34")
            {
                data34 = message.Message ?? string.Empty;
            }
            if (message.MessageType == "INTENSIVE35")
            {
                data35 = message.Message ?? string.Empty;
            }
            if (message.MessageType == "INTENSIVE36")
            {
                data36 = message.Message ?? string.Empty;
            }
            StateHasChanged();
        });
        await hubConnection2.StartAsync();

        //notificationService = new NotificationService(NavigationManager, Http);
        notificationService.MessageChanged += NotificationService_MessageChanged;
        _ = notificationService.InitializeNotifications();
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
        if (hubConnection1 is not null)
        {
            await hubConnection1.DisposeAsync();
        }

        if (hubConnection2 is not null)
        {
            await hubConnection2.DisposeAsync();
        }
    }

}

