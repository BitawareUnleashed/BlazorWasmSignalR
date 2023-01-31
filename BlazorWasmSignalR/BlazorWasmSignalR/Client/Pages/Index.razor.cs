using BlazorWasmSignalR.Client.Services;
using BlazorWasmSignalR.Shared.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Numerics;
using System.Reflection.Metadata;

namespace BlazorWasmSignalR.Client.Pages;

public partial class Index
{
    private HubConnection hubConnection;
    private List<string> messages = new List<string>();



    private NotificationService? notificationService;
    protected override async Task OnInitializedAsync()
    {

        hubConnection = new HubConnectionBuilder()
            .WithUrl(new Uri("https://localhost:7273/communicationhub"))
            .Build();

        hubConnection.On<NotificationTransport>("Message", message =>
            {
                messages.Add(message.Message + " - Index");
                StateHasChanged();
            });
        await hubConnection.StartAsync();

        notificationService = new NotificationService(NavigationManager, Http);
        notificationService.MessageChanged += NotificationService_MessageChanged;
        //return base.OnInitializedAsync();
    }

    private void NotificationService_MessageChanged(object? sender, string? e)
    {
        if(e is not null)
        {
            messages.Add(e);
        }
        
        StateHasChanged();
    }

    public async ValueTask DisposeAsync() { await hubConnection.DisposeAsync();  }

}

