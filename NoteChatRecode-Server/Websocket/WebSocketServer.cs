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
using NoteChatRecode_Common.Datapacket.Datapackets;

namespace NoteChatRecode_Server.Websocket
{
    public class WebSocketServer
    {
        private readonly HttpListener _httpListener;
        private readonly DataPacketManager _dataPacketManager;

        private UserService userService;
        public WebSocketServer(string uriPrefix)
        {
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(uriPrefix);
            _dataPacketManager = new DataPacketManager();

            userService = new UserService();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _httpListener.Start();
            Logger.Debug("WebSocket server started.");

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
                    client.socket = webSocket;
                    // ¶©ÔÄÊÂ¼þ
                    webSocket.OnConnected += (sender, e) =>
                    {
                        /*NoteChatServer.INSTANCE.EventManager.OnUserConnect(user, client);*/
                    };

                    webSocket.OnDisconnected += (sender, e) =>
                    {
                        if (user != null)
                        {
                            NoteChatServer.INSTANCE.EventManager.OnUserDisconnect(user, client);
                        }
                        NoteChatServer.INSTANCE.clientManager.RemoveClient(client); 
                    };

                    webSocket.OnPacketReceived += async (sender, e) =>
                    {
                        int packetId = e.Data[0];
                        if (_dataPacketManager.TryGetPacket(packetId, out var packet))
                        {
                            Logger.Debug("Received " + packet.ToString());
                            packet.Data = e.Data;
                            packet.ReadData();
                            if (packet is P99HandShakePacket handshakePacket)
                            {
                                if (!client.handshanked)
                                {
                                    Logger.Info("Handshake received from " + client.IP + ". Client time is " + handshakePacket.ClientTime);
                                    handshakePacket.ServerTime = DateTime.Now;
                                    handshakePacket.WriteData();
                                    await webSocket.SendPacketAsync(handshakePacket);
                                    client.handshanked = true;
                                    NoteChatServer.INSTANCE.clientManager.AddClient(client);
                                }

                            }
                            else if (packet is C08LoginRequestPacket loginPacket && client.handshanked)
                            {
                                if(client.User == null)
                                {
                                    user = new User(loginPacket.Username, loginPacket.Password, null);
                                    client.User = user;
                                    NoteChatServer.INSTANCE.EventManager.OnUserConnect(user, client);
                                }
                            }
                            else if (packet is C114PingPacket pingPacket)
                            {
                                Logger.Info("Ping received from " + client.IP);
                                
                                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Ping received", cancellationToken);
                            }
                            else
                            {
                                
                                NoteChatServer.INSTANCE.EventManager.OnUserPacket(user, packet);
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
