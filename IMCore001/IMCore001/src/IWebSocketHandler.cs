using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace IMCore001.src
{
    public interface IWebSocketHandler
    {
        Task Hand(HttpContext context, WebSocket webSocket);
    }
}
