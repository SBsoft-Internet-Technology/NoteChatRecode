using NoteChatRecode_Common.DataPack.Datapackets;
using NoteChatRecode_Server;
using NoteChatRecode_Server.Websocket;
using System;
using System.Text;
using System.Threading;
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

        // 初始化服务器
        NoteChatServer noteChatServer = new NoteChatServer("ExampleServer", "localhost", "8080");
        StartCommandInput(noteChatServer);
        await noteChatServer.server.StartAsync(CancellationToken.None);

        // 初始化命令输入系统
        
    }

    private static void StartCommandInput(NoteChatServer server)
    {
        // 在新线程中运行命令输入循环，避免阻塞主线程
        Task.Run(async () =>
        {
            while (true)
            {
                Console.Write("> "); // 命令提示符
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                // 处理命令输入
                await server.commandManager.ExecuteCommandAsync(input);
            }
        });
    }
}
