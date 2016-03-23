using Lime.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolframAlpha.Api.v2.Components;

namespace Science.Lab.Contact.Domain.Service.WolframAplha
{
    public interface IWolframAplhaService
    {
        Task<IEnumerable<Message>> Query(Message receivedMessage);
    }

    public class WolframAplhaService : IWolframAplhaService
    {
        #region Private Field

        private IWolframAplhaRepository _wolframAplhaRepository
        {
            get
            {
                return new WolframAplhaRepository();
            }
        }

        #endregion

        #region Constructor

        public WolframAplhaService()
        {
            
        }

        #endregion

        #region IWolframAplhaService members

        public async Task<IEnumerable<Message>> Query(Message message)
        {
            QueryResult queryResult = await _wolframAplhaRepository.Query(message.Content.ToString());
            var list = await QueryResult2MessageList(queryResult, "Image");
            return list;
        }

        private async Task<IEnumerable<Message>> QueryResult2MessageList(QueryResult result, string outputFormat)
        {
            var list = new List<Message>();
            foreach (Pod pod in result.Pods)
            {
                var response = await WolframPod2MessageList(pod, outputFormat);
                list.AddRange(response);
            };

            return list;
        }

        private async Task<IEnumerable<Message>> WolframPod2MessageList(Pod pod, string outputFormat)
        {
            var list = new List<Message>();
            foreach (SubPod subpod in pod.SubPods)
            {
                var response = await WolframSubPod2Message(subpod, outputFormat);
                list.AddRange(response);
            };

            return list;
        }

        private async Task<IEnumerable<Message>> WolframSubPod2Message(SubPod subpod, string outputFormat)
        {
            var messageList = await Task.Run<IEnumerable<Message>>(() =>
            {
                var list = new List<Message>();
                MediaType PlainType = new MediaType(MediaType.DiscreteTypes.Text, MediaType.SubTypes.Plain);
                var titleMessage = new Message
                {
                    Content = new PlainDocument(subpod.Title, PlainType)
                };

                if (outputFormat == "PlainText")
                {
                    string content = subpod.PlainText;
                    var message = new Message
                    {
                        Content = new PlainDocument(content, PlainType)
                    };
                    list.Add(message);
                }
                else if(outputFormat == "Image")
                {
                    string content = subpod.Img.Src;
                    var  imageType = new MediaType(MediaType.DiscreteTypes.Image, MediaType.SubTypes.Plain);
                    var message = new Message
                    {
                        Content = new PlainDocument(content, PlainType)
                    };
                    list.Add(message);
                }

                return list;
            });
            return messageList;
        }

        #endregion


    }
}
