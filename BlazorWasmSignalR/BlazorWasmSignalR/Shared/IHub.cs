using BlazorWasmSignalR.Shared.Models;

namespace BlazorWasmSignalR.Shared;

public interface IHub
{
    //List<string> ClientsList { get; set; }
    /// <summary>
    /// Receives the message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    Task SendMessage(object message);

    Task GetId(object id);





    Task SendToGroup(string groupName, NotificationTransport message);
    Task AddClientToGroup(string groupName);
    Task RemoveClientToGroup(string groupName);


}

