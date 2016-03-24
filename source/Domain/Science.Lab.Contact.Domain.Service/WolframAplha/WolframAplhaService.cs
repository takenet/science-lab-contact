using Lime.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takenet.Omni.Model;
using WolframAlpha.Api.v2.Components;

namespace Science.Lab.Contact.Domain.Service.WolframAplha
{
    public interface IWolframAplhaService
    {
        Task<IEnumerable<Document>> Query(Message receivedMessage);
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

        public async Task<IEnumerable<Document>> Query(Message message)
        {
            QueryResult queryResult = await _wolframAplhaRepository.Query(message.Content.ToString());
            var documents = await QueryResult2MessageList(queryResult, "Image");
            return documents;
        }

        private async Task<IEnumerable<Document>> QueryResult2MessageList(QueryResult result, string outputFormat)
        {
            var documents = new List<Document>();
            foreach (Pod pod in result.Pods)
            {
                var response = await WolframPod2MessageList(pod, outputFormat);
                documents.AddRange(response);
            };

            return documents;
        }

        private async Task<IEnumerable<Document>> WolframPod2MessageList(Pod pod, string outputFormat)
        {
            var documents = new List<Document>();
            foreach (SubPod subpod in pod.SubPods)
            {
                var response = await WolframSubPod2Message(subpod, outputFormat);
                documents.AddRange(response);
            };

            return documents;
        }

        private async Task<IEnumerable<Document>> WolframSubPod2Message(SubPod subpod, string outputFormat)
        {
            var documents = await Task.Run<IEnumerable<Document>>(() =>
            {
                var list = new List<Document>();
                MediaType PlainType = new MediaType(MediaType.DiscreteTypes.Text, MediaType.SubTypes.Plain);
                var titleMessage = new Message
                {
                    Content = new PlainDocument(subpod.Title, PlainType)
                };

                if (outputFormat == "PlainText")
                {
                    string content = subpod.PlainText;
                    var doc = new PlainDocument(content, PlainType);
                    list.Add(doc);
                }
                else if(outputFormat == "Image")
                {

                    var imageType = AttachmentMediaType.Image;
                    var mimeType = new MediaType("image", "gif");
                    var content = subpod.Img.Src;
                    var thumb = subpod.Img.Src;
                    var doc = new TextWithAttachments
                    {
                        Attachments = new[] {
                            new Attachment {
                                MediaType = imageType,
                                MimeType = new MediaType("image", "gif"),
                                RemoteUri = content,
                                ThumbnailUri = thumb
                            }
                        }
                    };
                    list.Add(doc);
                }

                return list;
            });
            return documents;
        }

        #endregion


    }
}
