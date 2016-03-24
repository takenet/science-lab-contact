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
        Task<List<ScienceLabDocument>> Query(Message receivedMessage);
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

        public async Task<List<ScienceLabDocument>> Query(Message message)
        {
            QueryResult queryResult = await _wolframAplhaRepository.Query(message.Content.ToString());
            var documents = await QueryResult2MessageList(queryResult);

            if (documents.Count > 1)
            {
                StringBuilder strBuild = new StringBuilder();
                strBuild.Append(documents[0].Document.ToString());
                strBuild.Append(", escolha: \n");
                for (int index = 1; index < documents.Count(); index++)
                {
                    strBuild.AppendFormat("{0}. {1}\n", index, documents[index].Title);
                }

                MediaType PlainType = new MediaType(MediaType.DiscreteTypes.Text, MediaType.SubTypes.Plain);
                string content = strBuild.ToString();
                var resultDoc = new PlainDocument(content, PlainType);
                documents[0].Document = resultDoc;
            }

            return documents;
        }

        private async Task<List<ScienceLabDocument>> QueryResult2MessageList(QueryResult result)
        {
            var documents = new List<ScienceLabDocument>();

            for (int i = 0; i < (result.Pods.Count() < 5 ? result.Pods.Count() : 5); i++)
            {
                if (result.Pods[i].Title.ToLower() != "input interpretation")
                {
                    var response = await WolframPod2MessageList(result.Pods[i]);
                    documents.AddRange(response);
                }
            }

            return documents;
        }

        private async Task<List<ScienceLabDocument>> WolframPod2MessageList(Pod pod)
        {
            var scienceLabDocument = new List<ScienceLabDocument>();

            foreach (SubPod subpod in pod.SubPods)
            {
                Document document = null;

                if (pod.Primary == "true")
                {
                    document = await WolframSubPod2Message(subpod, MediaType.DiscreteTypes.Text);
                }
                else
                {
                    document = await WolframSubPod2Message(subpod, MediaType.DiscreteTypes.Image);
                }

                scienceLabDocument.Add(new ScienceLabDocument { Title = pod.Title, Document = document });
            };

            return scienceLabDocument;
        }

        private async Task<Document> WolframSubPod2Message(SubPod subpod, string outputFormat)
        {
            var documents = await Task.Run<Document>(() =>
            {
                MediaType PlainType = new MediaType(MediaType.DiscreteTypes.Text, MediaType.SubTypes.Plain);
                if (outputFormat == MediaType.DiscreteTypes.Text)
                {
                    string content = subpod.PlainText;
                    var doc = new PlainDocument(content, PlainType);

                    return doc;
                }
                else if (outputFormat == MediaType.DiscreteTypes.Image)
                {
                    var imageType = AttachmentMediaType.Image;
                    var mimeType = new MediaType("image", "gif");
                    var content = subpod.Img.Src;
                    var thumb = subpod.Img.Src;
                    var doc = new TextWithAttachments
                    {
                        Text = subpod.Title,
                        Attachments = new[] {
                            new Attachment {
                                MediaType = imageType,
                                MimeType = new MediaType("image", "gif"),
                                RemoteUri = content,
                                ThumbnailUri = thumb,
                            }
                        }
                    };

                    return doc;
                }
                return null;
            });

            return documents;
        }

        #endregion


    }
}
