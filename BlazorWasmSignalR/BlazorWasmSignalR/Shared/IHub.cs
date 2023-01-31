namespace BlazorWasmSignalR.Shared;

public interface IHub
{
    /// <summary>
    /// Receives the message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    Task Message(object message);
}

