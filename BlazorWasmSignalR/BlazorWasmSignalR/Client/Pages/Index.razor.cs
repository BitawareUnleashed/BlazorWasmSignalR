using BlazorWasmSignalR.Client.Services;
using BlazorWasmSignalR.Shared.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Numerics;
using System.Reflection.Metadata;

namespace BlazorWasmSignalR.Client.Pages;

public partial class Index
{
    private HubConnection? hubConnection;
    private List<string> messages = new List<string>();

    private string Watch = string.Empty;

    private NotificationService? notificationService;
    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        hubConnection.On<NotificationTransport>("Message", message =>
            {
                if (message.MessageType == "TIME")
                {
                    Watch = message.Message ?? string.Empty;
                    StateHasChanged();
                }
            });
        await hubConnection.StartAsync();

        notificationService = new NotificationService(NavigationManager, Http);
        notificationService.MessageChanged += NotificationService_MessageChanged;
        notificationService.InitializeNotifications();
    }

    private void NotificationService_MessageChanged(object? sender, string? e)
    {
        if (e is not null)
        {
            messages.Add(e);
        }

        StateHasChanged();
    }

    public async ValueTask DisposeAsync() { await hubConnection.DisposeAsync(); }

}

