using NoteChatRecode_Common.Datapacket.Datapackets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Server.Command.Commands
{
    public class KickCommand : Command
    {
        public KickCommand() : base("kick", new[] { "k" }, async (args) =>
        {
            if (args.Length == 0)
            {
                Logger.Error("Usage: kick <username> [reason]");
                return;
            }
            var username = args[0];
            if (args.Length == 2)
            {
                var reason = args[1];
                var client = NoteChatServer.INSTANCE.clientManager.GetClient(username);
                if (client == null)
                {
                    Logger.Error("Client not found");
                    return;
                }
                await client.socket.SendPacketAsync(new S09KickPacket(reason));
                await client.socket.CloseAsync(System.Net.WebSockets.WebSocketCloseStatus.NormalClosure,"Kicked by server",CancellationToken.None);
                Logger.Info($"Kicked {username} for {reason}");
                return;
            }
            else {
                var client = NoteChatServer.INSTANCE.clientManager.GetClient(username);
                if (client == null)
                {
                    Logger.Error("Client not found");
                    return;
                }
                await client.socket.SendPacketAsync(new S09KickPacket());
                await client.socket.CloseAsync(System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, "Kicked by server", CancellationToken.None);
                Logger.Info($"Kicked {username}");
                await Task.CompletedTask;
            }
            
        })
        {
        }

    }
}
