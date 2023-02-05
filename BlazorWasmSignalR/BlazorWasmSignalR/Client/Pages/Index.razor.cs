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
    private HubConnection? hubConnection;
    private Article news;

    private string Watch = string.Empty;
    private string connectionId = string.Empty;

    private NotificationService? notificationService;
    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        _ = hubConnection.On<string>(nameof(IHub.GetId), GetMyId);

        hubConnection.On<NotificationTransport>(nameof(IHub.Message), message =>
            {
                Watch = message.Message ?? string.Empty;
                StateHasChanged();
            });
        await hubConnection.StartAsync();

        // Add to group
        await hubConnection.SendAsync("AddClientToGroup", "TIME");

        notificationService = new NotificationService(NavigationManager, Http);
        notificationService.MessageChanged += NotificationService_MessageChanged;
        _ = notificationService.InitializeNotifications();
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
        if (hubConnection is not null)
        {
            await hubConnection.DisposeAsync();
        }
    }

}

