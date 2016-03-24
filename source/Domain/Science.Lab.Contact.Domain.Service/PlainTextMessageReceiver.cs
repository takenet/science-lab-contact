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
using System.Text.RegularExpressions;

namespace Science.Lab.Contact.Domain.Service
{
    public class PlainTextMessageReceiver : MessageReceiverBase
    {
        #region Private Field
        
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

                document = documents.FirstOrDefault().Document;

                messageDictionary.TryAdd(message.From.Name, new MenuDocument { Count = 0, Documents = documents });
            }

            await EnvelopeSender.SendMessageAsync(document, message.From);

        }

        private Document GetCacheDocument(Message message)
        {
            Document result = null;
            
            Regex regex = new Regex(@"^\d+$");
            Match match = regex.Match(message.Content.ToString());

            if (match.Success)
            {
                MenuDocument menuDocument = null;

                if (messageDictionary.TryGetValue(message.From.Name, out menuDocument))
                {
                    try
                    {
                        result = menuDocument.Documents[int.Parse(message.Content.ToString())].Document;
                    }
                    catch (Exception)
                    {
                        
                    }
                    
                }
            }

            return result;
        }
    }

    public class MenuDocument
    {
        public int Count { get; set; }
        public List<ScienceLabDocument> Documents { get; set; }
    }
}
