using BlazorWasmSignalR.Server.Workers;
using BlazorWasmSignalR.Shared;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;

namespace BlazorWasmSignalR.Server.Models.Hub
{
    public class CommunicationHub : Hub<IHubClient>
    {
        #region Fields
        // definire gruppi dinamici

        private SimpleWorker worker;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationHub" /> class.
        /// </summary>
        //public CommunicationHub(SimpleWorker worker)
        //{
        //    this.worker = worker;
        //    _ = this.worker.ExecuteAsync(new CancellationToken());
        //}

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
        public async Task ReceiveMessage(object message) => await Clients.All.ReceiveMessage(message);

        #endregion
    }
}
