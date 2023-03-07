using BlazorWasmSignalR.Server.Workers;
using BlazorWasmSignalR.Shared;
using Microsoft.AspNetCore.SignalR;
using System;

namespace BlazorWasmSignalR.Server.Models.Hub;

public class CommunicationHub : Hub<IHub>
{
    public async Task Message(object message) => await Clients.All.Message(message);


    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }
}

public class SecondHub : Hub<IHub>
{
    public async Task Message(object message) => await Clients.All.Message(message);

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }
}