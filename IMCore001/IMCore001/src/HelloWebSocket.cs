using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IMCore001.src
{
    public class HelloWebSocket : IWebSocketHandler,IDisposable
    {
        static readonly int TimeOutSeconds = 180; //3分钟未收到心跳超时
        DateTime dtLastPackage;
        System.Timers.Timer timer;
        WebSocket websocket;
        public HelloWebSocket()
        {
            dtLastPackage = DateTime.Now;
            timer = new System.Timers.Timer();
            timer.Interval = 10000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           
            TimeSpan tsDiff = DateTime.Now - dtLastPackage;
            if (tsDiff.TotalSeconds > TimeOutSeconds) {
                timer.Stop();
                Dispose();
            }           
        }
        public async Task Hand(HttpContext context, WebSocket webSocket)
        {
            this.websocket = webSocket;
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue) {
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
        /// <summary>
        /// 主动发送
        /// </summary>
        protected void HandlerSend()
        {

        }
        /// <summary>
        /// 处理命令
        /// </summary>
        protected void HandlerReceive()
        {

        }
        public void Dispose()
        {
            if (timer != null) {
                timer.Stop();
                timer.Dispose();
            }
            if (websocket != null)
                websocket.Dispose();
        }
    }
}
