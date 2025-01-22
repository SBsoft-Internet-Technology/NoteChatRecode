﻿using NoteChatRecode_Common.DataPack.Datapackets;
using NoteChatRecode_Server;
using NoteChatRecode_Server.Websocket;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine(@".__   __.   ______   .___________. _______   ______  __    __       ___   .___________.
|  \ |  |  /  __  \  |           ||   ____| /      ||  |  |  |     /   \  |           |
|   \|  | |  |  |  | `---|  |----`|  |__   |  ,----'|  |__|  |    /  ^  \ `---|  |----`
|  . `  | |  |  |  |     |  |     |   __|  |  |     |   __   |   /  /_\  \    |  |     
|  |\   | |  `--'  |     |  |     |  |____ |  `----.|  |  |  |  /  _____  \   |  |     
|__| \__|  \______/      |__|     |_______| \______||__|  |__| /__/     \__\  |__|     
                                                                                       ");
        Console.Write("NoteChatRecode-Server");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(" v1.0.0");
        Console.ResetColor();
        Logger.Warning("This is a development build and is not intended for production use.");
        Logger.Info("Starting server...");
        WebSocketServer server = new WebSocketServer("http://localhost:8080/");
        await server.StartAsync(CancellationToken.None);

        
    }
}
