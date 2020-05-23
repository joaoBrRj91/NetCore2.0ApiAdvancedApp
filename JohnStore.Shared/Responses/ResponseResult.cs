

using JohnStore.Shared.Commands;
using System.Collections.Generic;
using System.Net;

namespace johnstore.shared.Responses
{
    public class ResponseResult
    {

        public ResponseResult(ICommandResult data)
        {
            Data = data;
            Notifications = Data.Notifications;
            Success = Data.Success;
        }

        public bool Success { get; }
        public ICommandResult Data { get; private set; }
        public HttpStatusCode StatusCode => Notifications.Count > 0 ? HttpStatusCode.BadRequest : HttpStatusCode.OK;
        public IDictionary<string, string> Notifications { get; private set; }
    }
}
