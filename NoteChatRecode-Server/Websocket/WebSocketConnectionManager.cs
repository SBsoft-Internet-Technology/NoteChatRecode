using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Server.Websocket
{
    public class WebSocketConnectionManager
    {
        private readonly ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();

        public WebSocket GetSocketById(string id)
        {
            return _sockets.FirstOrDefault(p => p.Key == id).Value;
        }

        public ConcurrentDictionary<string, WebSocket> GetAll()
        {
            return _sockets;
        }

        public string GetId(WebSocket socket)
        {
            return _sockets.FirstOrDefault(p => p.Value == socket).Key;
        }

        public async Task RemoveSocket(string id)
        {
            _sockets.TryRemove(id, out WebSocket socket);

            if (socket != null)
            {
                await socket.CloseAsync(closeStatus: WebSocketCloseStatus.NormalClosure,
                                        statusDescription: "Closed by the WebSocketConnectionManager",
                                        cancellationToken: CancellationToken.None);
            }
        }

        public void AddSocket(WebSocket socket)
        {
            string id = Guid.NewGuid().ToString();
            _sockets.TryAdd(id, socket);
        }
    }
}
