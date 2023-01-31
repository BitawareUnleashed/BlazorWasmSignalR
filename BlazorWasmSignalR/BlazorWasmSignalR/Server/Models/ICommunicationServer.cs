namespace BlazorWasmSignalR.Server.Models;

public interface ICommunicationServer
{
    /// <summary>
    /// Sends the channel activation message.
    /// </summary>
    void SendChannelActivationMessage();

    /// <summary>
    /// Sends the specified message.
    /// </summary>
    /// <param name="toSend">To send.</param>
    void Send(object toSend);
}
