using NoteChatRecode_Client_Common.Websocket;
using NoteChatRecode_Common.Core.User;
using NoteChatRecode_Common.DataPack.Datapackets;
using NoteChatRecode_Common.Datapacket.Datapackets;
using NoteChatRecode_Common.Message.Messages;
using NoteChatRecode_Common.Websocket.Datapacket.Datapackets;
using System.Diagnostics;
using System.Net.WebSockets;

namespace NoteChatRecode_Client_WinForm
{
    public partial class Form1 : Form
    {
        public static Form1 INSTANCE;
        public WebSocketClient client;
        public Form1()
        {
            InitializeComponent();
            INSTANCE = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new WebSocketClient();

            // 订阅事件
            client.OnConnected += (sender, e) => Console.WriteLine("Connected to server.");
            client.OnDisconnected += (sender, e) => Console.WriteLine("Disconnected from server.");
            client.OnPacketReceived += (sender, e) =>
            {
                int packetId = e.Data[0];
                Debug.WriteLine($"Received packet with ID: {packetId}");
                if (packetId == 7)
                {
                    Debug.WriteLine(1);
                    var packet = new S07LoginResponsePacket();
                    Debug.WriteLine(2);
                    packet.Data = e.Data;
                    Debug.WriteLine(3);
                    packet.ReadData();
                    Debug.WriteLine(4);
                    label2.Text = packet.Message;
                    Debug.WriteLine(5); 
                    Debug.WriteLine(packet.Message);
                }
                if (packetId == 114) {
                    var pingPacket = new C114PingPacket();
                    pingPacket.Data = e.Data;
                    pingPacket.ReadData();
                    Debug.WriteLine($"Ping received: name={pingPacket.name}, desp={pingPacket.desp}, servertime={pingPacket.servertime}");
                    // 处理ping包后的逻辑，例如更新UI
                    label2.Text = $"Ping: {pingPacket.name}, {pingPacket.desp}, {pingPacket.servertime}";


                }
            };
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {


            // 连接到服务器
            await client.ConnectAsync("ws://localhost:8080/", CancellationToken.None);
            label2.Text = "食人树：" + client.servertime;



            /*await client.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client closed", CancellationToken.None);*/

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await client.SendPacketAsync(new C08LoginRequestPacket(textBox3.Text, textBox4.Text));
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await client.SendPacketAsync(new P01TextMessagePacket());
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            client = new WebSocketClient();
            await client.ConnectAsync("ws://localhost:8080/", CancellationToken.None);
            await client.SendPacketAsync(new C114PingPacket());
        }
    }
}
