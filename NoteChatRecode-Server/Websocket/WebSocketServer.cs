using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using NoteChatRecode_Server.Event;
using NoteChatRecode_Server.Core.User;
using NoteChatRecode_Server.Websocket.Datapacket.Datapackets;
using System.Net;
using NoteChatRecode_Common.Core.User;

namespace NoteChatRecode_Server.Websocket
{
    public class WebSocketServer
    {
        private readonly HttpListener _httpListener;
        private readonly DataPacketManager _dataPacketManager;
        private readonly Event.Event _eventManager;

        public WebSocketServer(string uriPrefix)
        {
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(uriPrefix);
            _dataPacketManager = new DataPacketManager();
            _eventManager = new Event.Event();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _httpListener.Start();
            Logger.Info("WebSocket server started.");

            while (!cancellationToken.IsCancellationRequested)
            {
                var httpContext = await _httpListener.GetContextAsync();
                if (httpContext.Request.IsWebSocketRequest)
                {
                    var webSocketContext = await httpContext.AcceptWebSocketAsync(null);
                    
                    var webSocket = new WebSocket(webSocketContext.WebSocket);
                    User user;
                    // 订阅事件
                    /*webSocket.OnConnected += (sender, e) => _eventManager.OnUserConnect(user);
                    webSocket.OnDisconnected += (sender, e) => _eventManager.OnUserDisconnect(user);*/
                    webSocket.OnPacketReceived += (sender, e) =>
                    {
                        int packetId = e.Data[0]; // 假设第一个字节是数据包ID
                        if(packetId.Equals(0x00))
                        {
                            
                        }
                        if (_dataPacketManager.TryGetPacket(packetId, out var packet))
                        {
                            packet.Data = e.Data;
                            packet.ReadData();
                            /*_eventManager.OnUserPacket(user, packet);*/
                        }
                        else
                        {
                            Console.WriteLine($"Unknown packet ID: {packetId}");
                        }
                    };

                    _ = webSocket.HandleConnectionAsync(cancellationToken);
                }
                else
                {
                    httpContext.Response.StatusCode = 400;
                    httpContext.Response.Close();
                }
            }
        }
    }
}
