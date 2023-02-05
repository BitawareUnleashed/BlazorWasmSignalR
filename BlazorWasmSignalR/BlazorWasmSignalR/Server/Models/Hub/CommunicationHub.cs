using BlazorWasmSignalR.Server.Workers;
using BlazorWasmSignalR.Shared;
using BlazorWasmSignalR.Shared.Models;
using Microsoft.AspNetCore.SignalR;
using System;

namespace BlazorWasmSignalR.Server.Models.Hub;

public class CommunicationHub : Hub<IHub>
{
    public static List<string> ClientsList { get; set; }=new List<string>();

    public async Task Message(object message) => await Clients.All.Message(message);

    public async Task GetId(object id)
    {
        await Clients.Caller.GetId(Context.ConnectionId);
    }

    #region GROUPS
    public async Task SendToGroup(string groupName, NotificationTransport message)
    {
        await Clients.Group(groupName).Message(message);
    }

    public async Task AddClientToGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public async Task RemoveClientToGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        await Clients.Client(Context.ConnectionId).Message("Removed from group");
    }
    #endregion


    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.GetId(Context.ConnectionId.ToString());
        ClientsList.Add(Context.ConnectionId);
        await base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        ClientsList.Remove(Context.ConnectionId);
        return base.OnDisconnectedAsync(exception);
    }
}
