using Lime.Protocol;
using Science.Lab.Contact.Domain.Service.WolframAplha;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Takenet.MessagingHub.Client;
using Takenet.MessagingHub.Client.Receivers;
using Takenet.Omni.Model;
using System.Linq;

namespace Science.Lab.Contact.Domain.Service
{
    public class PlainTextMessageReceiver : MessageReceiverBase
    {
        #region Private Field

        private static string _moreWords = "more + mais";

        private static object _syncRoot = new object();
        private static ConcurrentDictionary<string, MenuDocument> _messageDictionary;

        private IWolframAplhaService _wolframAplhaService
        {
            get
            {
                return new WolframAplhaService();
            }
        }

        #endregion

        #region Protected fields

        protected static ConcurrentDictionary<string, MenuDocument> messageDictionary
        {
            get
            {
                if (_messageDictionary == null)
                {
                    lock (_syncRoot)
                    {
                        if (_messageDictionary == null)
                        {
                            _messageDictionary = new ConcurrentDictionary<string, MenuDocument>();
                        }
                    }
                }

                return _messageDictionary;
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
            var document = GetCacheDocument(message);

            if (document == null)
            {
                var documents = await _wolframAplhaService.Query(message);

                MenuDocument menuDocument = null;
                messageDictionary.TryRemove(message.From.Name, out menuDocument);

                messageDictionary.TryAdd(message.From.Name, new MenuDocument { Count = 0, Documents = documents.ToList() });
            }

            await EnvelopeSender.SendMessageAsync(document, message.From);

        }

        private Document GetCacheDocument(Message message)
        {
            Document result = null;

            MenuDocument menuDocument = null;

            if (_moreWords.Contains(message.Content.ToString().ToLower()))
            {
                if (messageDictionary.TryGetValue(message.From.Name, out menuDocument))
                {
                    menuDocument.Count += 1;

                    if (menuDocument.Count < menuDocument.Documents.Count)
                    {
                        result = menuDocument.Documents[menuDocument.Count];
                    }
                    else
                    {
                        messageDictionary.TryRemove(message.From.Name, out menuDocument);
                    }
                }
            }

            return result;
        }
    }

    public class MenuDocument
    {
        public int Count { get; set; }
        public List<Document> Documents { get; set; }
    }
}
