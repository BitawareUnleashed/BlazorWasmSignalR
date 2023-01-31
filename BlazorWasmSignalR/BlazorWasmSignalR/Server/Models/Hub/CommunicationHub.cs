using BlazorWasmSignalR.Server.Workers;
using BlazorWasmSignalR.Shared;
using Microsoft.AspNetCore.SignalR;
using System;

namespace BlazorWasmSignalR.Server.Models.Hub
{
    public class CommunicationHub : Hub<IHubClient>
    {
        #region Fields
        // definire gruppi dinamici

        //private SimpleWorker worker;
        #endregion

        #region Constructors

        #endregion

        #region Methods and callbacks

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public async Task SendMessage(object message) => await Clients.All.SendMessage(message);

        /// <summary>
        /// Receives the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public async Task Message(object message) => await Clients.All.Message(message);

        #endregion

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
    }
}
