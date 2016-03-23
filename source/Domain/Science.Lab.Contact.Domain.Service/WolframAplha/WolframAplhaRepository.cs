using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolframAlpha.Api.v2;
using WolframAlpha.Api.v2.Components;
using WolframAlpha.Api.v2.Requests;

namespace Science.Lab.Contact.Domain.Service.WolframAplha
{
    public interface IWolframAplhaRepository
    {
        Task<QueryResult> Query(string inputQuery);
    }

    public class WolframAplhaRepository : IWolframAplhaRepository
    {
        private string _wolframAlphaAccessKey;

        public WolframAplhaRepository()
        {
            _wolframAlphaAccessKey = "VJJR44-EE2LXRPRGG";
        }

        public async Task<QueryResult> Query(string inputQuery)
        {
            var builder = new QueryBuilder();
            builder.AppId = _wolframAlphaAccessKey;
            builder.Input = inputQuery;
            builder.Format = "PlainText";

            var request = new QueryRequest();
            var uri = builder.QueryUri;
            try
            {
                var result = await request.ExecuteAsync(uri);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
