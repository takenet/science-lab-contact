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

        private static readonly MediaType ResponseMediaType = new MediaType("application", "vnd.omni.text", "json");

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

            //var document = new TextWithAttachments
            //{
            //    Attachments = new[] { new Attachment { MediaType = AttachmentMediaType.Image, MimeType = new MediaType("image", "gif"),
            //        RemoteUri = "http://www5b.wolframalpha.com/Calculate/MSP/MSP12431f8ihf1a1h8140gc00003cef9379c89321ci?MSPStoreType=image/gif&s=23", ThumbnailUri = "http://www5b.wolframalpha.com/Calculate/MSP/MSP12431f8ihf1a1h8140gc00003cef9379c89321ci?MSPStoreType=image/gif&s=23"} }
            //};

            //await EnvelopeSender.SendMessageAsync(new Message { Content = document, To = message.From });

            foreach (var document in documents)
            {
                await EnvelopeSender.SendMessageAsync(document, message.From);
            }
        }

    }
}
