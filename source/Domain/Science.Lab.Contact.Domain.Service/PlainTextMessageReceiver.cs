using Lime.Protocol;
using Science.Lab.Contact.Domain.Service.WolframAplha;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Takenet.MessagingHub.Client;
using Takenet.MessagingHub.Client.Receivers;
using Takenet.Omni.Model;

namespace Science.Lab.Contact.Domain.Service
{
    public class PlainTextMessageReceiver : MessageReceiverBase
    {
        #region Private Field

        private IWolframAplhaService _wolframAplhaService
        {
            get
            {
                return new WolframAplhaService();
            }
        }

        #endregion

        #region Constructor

        public PlainTextMessageReceiver()
        {

        }

        #endregion

        public override async Task ReceiveAsync(Message message)
        {
            var documents = await _wolframAplhaService.Query(message);
            foreach (var document in documents)
            {
                await EnvelopeSender.SendMessageAsync(document, message.From);
            }
        }

    }
}
