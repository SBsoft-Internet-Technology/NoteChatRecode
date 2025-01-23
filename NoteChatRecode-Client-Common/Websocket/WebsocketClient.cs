using System;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using NoteChatRecode_Common;
using NoteChatRecode_Common.DataPack.Datapackets;
using NoteChatRecode_Common.Datapacket;
using NoteChatRecode_Common.Datapacket.Datapackets;

namespace NoteChatRecode_Client_Common.Websocket
{
    public class WebSocketClient
    {
        private ClientWebSocket _clientWebSocket;
        public string servertime = "";
        // 定义事件
        public event EventHandler OnConnected;
        public event EventHandler OnDisconnected;
        public event EventHandler<DataPacketEventArgs> OnPacketReceived;

        public WebSocketClient()
        {
            _clientWebSocket = new ClientWebSocket();
        }

        public async Task ConnectAsync(string uri, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Connecting to the server...");
            await _clientWebSocket.ConnectAsync(new Uri(uri), cancellationToken);
            OnConnected?.Invoke(this, EventArgs.Empty); // 触发连接事件
            await SendHandshakeAsync(); // 发送握手数据包
            _ = ReceiveLoopAsync(cancellationToken); // 开始接收数据包
        }

        private async Task SendHandshakeAsync()
        {
            var handshakePacket = new P99HandShakePacket
            {
                ClientTime = DateTime.Now
            };
            handshakePacket.WriteData();
            await SendPacketAsync(handshakePacket);
        }

        public async Task SendPacketAsync(DataPacket packet)
        {
            packet.WriteData();
            await _clientWebSocket.SendAsync(new ArraySegment<byte>(packet.Data), WebSocketMessageType.Binary, true, CancellationToken.None);
        }

        private async Task ReceiveLoopAsync(CancellationToken cancellationToken)
        {
            var buffer = new byte[1024 * 4];
            while (_clientWebSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
            {
                var result = await ReceiveAsync(buffer, cancellationToken);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by the WebSocket", cancellationToken);
                }
                else
                {
                    var data = new byte[result.Count];
                    Array.Copy(buffer, data, result.Count);
                    OnPacketReceived?.Invoke(this, new DataPacketEventArgs(data)); // 触发接收数据包事件

                    // 处理握手响应
                    var packetId = data[0];
                    if (packetId == 99)
                    {
                        var handshakePacket = new P99HandShakePacket();
                        handshakePacket.Data = data;
                        handshakePacket.ReadData();
                        Debug.WriteLine($"食人树: {handshakePacket.ServerTime}");
                        servertime = handshakePacket.ServerTime.ToString();

                    }
                    if (packetId == 9) {
                    
                        Debug.WriteLine("kick");
                        await CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by the WebSocket", cancellationToken);

                    }
                }
            }
        }

        public async Task<WebSocketReceiveResult> ReceiveAsync(byte[] buffer, CancellationToken cancellationToken)
        {
            return await _clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
        }

        public async Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
        {
            await _clientWebSocket.CloseAsync(closeStatus, statusDescription, cancellationToken);
            OnDisconnected?.Invoke(this, EventArgs.Empty); // 触发断开连接事件
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
