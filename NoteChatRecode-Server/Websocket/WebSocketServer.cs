using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using NoteChatRecode_Server.Event;
using NoteChatRecode_Server.Core.User;
using NoteChatRecode_Server.Websocket.Datapacket.Datapackets;
using System.Net;
using NoteChatRecode_Common.Core.User;
using NoteChatRecode_Common.Websocket.Datapacket.Datapackets;
using NoteChatRecode_Common.DataPack.Datapackets;
using NoteChatRecode_Server.Core.Client;

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
            Console.WriteLine("WebSocket server started.");

            while (!cancellationToken.IsCancellationRequested)
            {
                var httpContext = await _httpListener.GetContextAsync();
                if (httpContext.Request.IsWebSocketRequest)
                {
                    var webSocketContext = await httpContext.AcceptWebSocketAsync(null);

                    var webSocket = new WebSocket(webSocketContext.WebSocket);
                    User user = null;
                    string clientIp = httpContext.Request.RemoteEndPoint?.Address.ToString();
                    Client client = new Client(clientIp);
                    // �����¼�
                    webSocket.OnConnected += (sender, e) =>
                    {
                        /*var loginPacket = e as S00LoginRequestPacket;
                        if (loginPacket != null)
                        {
                            user = new User(loginPacket.Username, loginPacket.Password, null)
                            
                            _eventManager.OnUserConnect(user);
                        }*/

                    };

                    webSocket.OnDisconnected += (sender, e) =>
                    {
                        if (user != null)
                        {
                            _eventManager.OnUserDisconnect(user);
                        }
                    };

                    webSocket.OnPacketReceived += (sender, e) =>
                    {
                        int packetId = e.Data[0]; // �����һ���ֽ������ݰ�ID
                        if (_dataPacketManager.TryGetPacket(packetId, out var packet))
                        {
                            packet.Data = e.Data;
                            packet.ReadData();
                            if (packet is S00LoginRequestPacket loginPacket)
                            {
                                user = new User(loginPacket.Username, loginPacket.Password, null);
                                
                                _eventManager.OnUserConnect(user);
                            }
                            else
                            {
                                _eventManager.OnUserPacket(user, packet);
                            }
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
