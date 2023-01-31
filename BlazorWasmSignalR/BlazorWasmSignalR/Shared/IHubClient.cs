namespace BlazorWasmSignalR.Shared;

public interface IHubClient
{
    /// <summary>
    /// Receives the message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    Task Message(object message);

    /// <summary>
    /// Sends the message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    Task SendMessage(object message);
}

