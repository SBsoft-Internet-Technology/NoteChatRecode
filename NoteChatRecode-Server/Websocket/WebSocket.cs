using NoteChatRecode_Server.Websocket.Datapacket;
using System.Threading;
using System;
using System.Threading.Tasks;
using System.Net.WebSockets;
using NoteChatRecode_Common;
using System.Diagnostics;
using System.Text;

namespace NoteChatRecode_Server.Websocket
{
    public class WebSocket
    {
        private System.Net.WebSockets.WebSocket _webSocket;

        public WebSocket(System.Net.WebSockets.WebSocket webSocket)
        {
            _webSocket = webSocket;
        }

        public WebSocket()
        {
        }

        // 定义事件
        public event EventHandler OnConnected;
        public event EventHandler OnDisconnected;
        public event EventHandler<DataPacketEventArgs> OnPacketReceived;

        public async Task SendAsync(byte[] buffer, System.Net.WebSockets.WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
        {
            await _webSocket.SendAsync(new ArraySegment<byte>(buffer), messageType, endOfMessage, cancellationToken);
        }

        public async Task SendPacketAsync(DataPacket packet)
        {
            packet.WriteData();
            await _webSocket.SendAsync(new ArraySegment<byte>(packet.Data), System.Net.WebSockets.WebSocketMessageType.Binary, true, CancellationToken.None);
        }

        public async Task<System.Net.WebSockets.WebSocketReceiveResult> ReceiveAsync(byte[] buffer, CancellationToken cancellationToken)
        {
            return await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
        }

        public async Task CloseAsync(System.Net.WebSockets.WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
        {
            Logger.Debug("Client disconnected.");
            await _webSocket.CloseAsync(closeStatus, statusDescription, cancellationToken);
            OnDisconnected?.Invoke(this, EventArgs.Empty); // 触发断开连接事件
        }

        public async Task HandleConnectionAsync(CancellationToken cancellationToken)
        {
            OnConnected?.Invoke(this, EventArgs.Empty); // 触发连接事件
            Logger.Debug("Client connected.");
            var buffer = new byte[1024 * 4];
            while (_webSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
            {
                var result = await ReceiveAsync(buffer, cancellationToken);
                var filteredBuffer = buffer.Take(result.Count).Where(b => b != 0).ToArray();
                
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by the WebSocket", cancellationToken);
                }
                else
                {
                    var data = new byte[filteredBuffer.Length];
                    Array.Copy(filteredBuffer, data, filteredBuffer.Length);
                    OnPacketReceived?.Invoke(this, new DataPacketEventArgs(data)); // 触发接收数据包事件
                }
            
            }
        }
    }

    // 数据包事件参数类
    public class DataPacketEventArgs : EventArgs
    {
        public byte[] Data { get; }

        public DataPacketEventArgs(byte[] data)
        {
            Data = data;
        }
    }
}
